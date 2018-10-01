/*
COPYRIGHT 1995-2009 ESRI
TRADE SECRETS: ESRI PROPRIETARY AND CONFIDENTIAL
Unpublished material - all rights reserved under the 
Copyright Laws of the United States.
For additional information, contact:
Environmental Systems Research Institute, Inc.
Attn: Contracts Dept
380 New York Street
Redlands, California, USA 92373
email: contracts@esri.com
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using ArcGIS.Desktop.Framework;
using ArcGIS.Desktop.Metadata;
using ArcGIS.Desktop.Metadata.Editor.Pages;
using ArcGIS.Desktop.Metadata.Editor.Validation;

namespace MetadataToolkit.Pages
{
  /// <summary>
  /// Interaction logic for MTK_EditorRichTextBox.xaml
  /// </summary>
  internal partial class MTK_EditorRichTextBox : EditorPage
  {
    // need to cache this b/c the data context is reset
    // before UnLoaded event is called
    private object cachedContext = null;
    private RichTextBox cachedRTB = null;

    public MTK_EditorRichTextBox()
    {
      InitializeComponent();

      // see: http://msmvps.com/blogs/theproblemsolver/archive/2008/12/29/how-to-know-when-the-datacontext-changed-in-your-control.aspx
      //SetBinding(MyDataContextProperty, new Binding());

      var editorPage = this;
      this.AddHandler(MetadataRules.MetadataXMLUpdatedEvent, new RoutedEventHandler(delegate(object sender2, RoutedEventArgs rea)
      {
        // create event and raise it
        MetadataRuleSet rules = editorPage.cachedRTB.GetValue(MetadataRules.RulesProperty) as MetadataRuleSet;
        if (null != rules)
          rules.RunRules(editorPage.cachedRTB, null);
      }));
    }

    public void LoadedItemInfo(object sender, RoutedEventArgs e)
    {
      object context = Utils.Utils.GetDataContext(sender);

      // If this page is declared in the window,
      // the intial data context will be NULL.
      //
      // A second pass, will set this context
      // and the control will work...
      if (null == context)
        return;

      var mdModule = FrameworkApplication.FindModule("esri_metadata_module") as IMetadataEditorHost;
      if (mdModule != null)
        mdModule.SetIsLoadingPage(this, true);

      // Cache this context for the unload event.
      // When unload is called, the context is already cleared
      this.cachedContext = context;
      this.cachedRTB = sender as RichTextBox;

      // load it
      Utils.Utils.LoadRichTextbox(sender, context);

      // add me, so I can be called later
      if (mdModule != null)
        mdModule.AddCommitPage(this);

      var editorPage = this;

      // update XML on lost focus
      this.LostFocus += new RoutedEventHandler(delegate(object sender2, RoutedEventArgs rea)
      {
        Utils.Utils.UnLoadRichTextbox(editorPage.cachedRTB, editorPage.cachedContext, true);

        // create event and raise it
        MetadataRuleSet rules = editorPage.cachedRTB.GetValue(MetadataRules.RulesProperty) as MetadataRuleSet;
        if (null != rules)
          rules.RunRules(editorPage.cachedRTB, null);

        SetBorderOnError();
      });

      // create event and raise it
      {
        Utils.Utils.UnLoadRichTextbox(editorPage.cachedRTB, editorPage.cachedContext, true);

        // create event and raise it
        MetadataRuleSet rules = editorPage.cachedRTB.GetValue(MetadataRules.RulesProperty) as MetadataRuleSet;
        if (null != rules)
          rules.RunRules(editorPage.cachedRTB, null);
      }

      SetBorderOnError();

      if (mdModule != null)
        mdModule.SetIsLoadingPage(this, false);
    }

    private void SetBorderOnError()
    {
      XAMLRichBox_Border.BorderBrush = ((bool) XAMLRichBox.GetValue(MetadataRules.HasIssueProperty))
        ? (Brush)FindResource("Esri_Red2")
        : Brushes.Transparent;
    }

    override public void CommitChanges()
    {
      // TODO: TextChanged is currently not working!
      if (null == this.cachedRTB || null == this.cachedContext)
        return;

      Utils.Utils.UnLoadRichTextbox(this.cachedRTB, this.cachedContext, true);
    }

    /**** COMMANDS ****/

    public static readonly RoutedUICommand HyperlinkCommand = new RoutedUICommand(
      /*"Do something", "DoSomething", typeof(UserControl)*/);


    public static readonly RoutedUICommand IncreaseFontSizeCommand = new RoutedUICommand(
      /*"Do something", "DoSomething", typeof(UserControl)*/);

    public static readonly RoutedUICommand DecreaseFontSizeCommand = new RoutedUICommand(
      /*"Do something", "DoSomething", typeof(UserControl)*/);

    internal void DecreaseFontSizeCommandCanExecute(object sender, CanExecuteRoutedEventArgs e)
    {
      e.CanExecute = true;
      e.Handled = true;
    }

    internal void DecreaseFontSizeCommandExecuted(object target, ExecutedRoutedEventArgs e)
    {

      RichTextBox rtb = target as RichTextBox;
      TextPointer selStart = rtb.Selection.Start;
      TextPointer selEnd = rtb.Selection.End;

      if (selStart.IsAtInsertionPosition)
      {

        // look for the largest styles between 
        TextPointer startTagPointer = SeekEnclosingStartTag(selStart);
        if (null == startTagPointer)
          return; // NOOP

        object element = startTagPointer.GetAdjacentElement(LogicalDirection.Backward);
        if (element is UIElement)
        {
          UIElement uiElement = element as UIElement;
        }
        else if (element is TextElement)
        {
          TextElement textElement = element as TextElement;
          double size = textElement.FontSize;
          ChangeFontSize(selStart, size, selEnd, false);
        }
        else
        {
          return; // NOOP
        }
      }
    }

    internal void IncreaseFontSizeCommandCanExecute(object sender, CanExecuteRoutedEventArgs e)
    {
      e.CanExecute = true;
      e.Handled = true;
    }

    internal void IncreaseFontSizeCommandExecuted(object target, ExecutedRoutedEventArgs e)
    {
  
      RichTextBox rtb = target as RichTextBox;
      TextPointer selStart = rtb.Selection.Start;
      TextPointer selEnd = rtb.Selection.End;    

      if (selStart.IsAtInsertionPosition)
      {

        // look for the largest styles between 
        TextPointer startTagPointer = SeekEnclosingStartTag(selStart);
        if (null == startTagPointer)
          return; // NOOP

        object element = startTagPointer.GetAdjacentElement(LogicalDirection.Backward);
        if (element is UIElement)
        {
          UIElement uiElement = element as UIElement;          
        }
        else if (element is TextElement)
        {
          TextElement textElement = element as TextElement;
          double size = textElement.FontSize;
          ChangeFontSize(selStart, size, selEnd, true);
        }
        else
        {
          return; // NOOP
        }
      }
    }

    private double GetPreviousFontSize(double size)
    {
      // xx-small | x-small | small | medium | large | x-large | xx-large
      // 8, 9, 10, [11], 12, 14, 16

      if (10.0 == size)
        return 9.0;
      else if (11.0 == size)
        return 10.0;
      else if (12.0 == size)
        return 11.0;
      else if (14.0 == size)
        return 12.0;
      else if (16.0 == size)
        return 14.0;
      else
        return 8.0;
    }

    private double GetNextFontSize(double size)
    {
      // xx-small | x-small | small | medium | large | x-large | xx-large
      // 8, 9, 10, [11], 12, 14, 16

      if (8.0 == size)
        return 9.0;
      else if (9.0 == size)
        return 10.0;
      else if (10.0 == size)
        return 11.0;
      else if (11.0 == size)
        return 12.0;
      else if (12.0 == size)
        return 14.0;
      else
        return 16.0;
    }

    private void ChangeFontSize(TextPointer currentPoint, double size, TextPointer endingPoint, bool increase)
    {
      // currentPoint can split text, but size is the text's size based on the enclosing tag

      // find the next position
      TextPointer next = currentPoint.GetNextContextPosition(LogicalDirection.Forward);
      //TextPointerContext nextCtx = currentPoint.GetPointerContext(LogicalDirection.Forward);

      int currentOffset = next.GetOffsetToPosition(endingPoint);
      TextPointer endOfApply = (currentOffset <= 0) ? endingPoint : next;

      // apply the style for this portion
      TextRange range = new TextRange(currentPoint, endOfApply);
      try
      {        
        string text = currentPoint.GetTextInRun(LogicalDirection.Forward);
        double newSize = increase ? GetNextFontSize(size) : GetPreviousFontSize(size);
        range.ApplyPropertyValue(TextElement.FontSizeProperty, newSize);
      }
      catch (Exception)
      {
        // ignore
        return;
      }

      if (currentOffset <= 0)
        return; // done

      // what's next?
      object element = endOfApply.GetAdjacentElement(LogicalDirection.Forward);
      TextPointerContext ctx = endOfApply.GetPointerContext(LogicalDirection.Forward);
      if (element is UIElement)
      {
        UIElement uiElement = element as UIElement;
      }
      else if (element is TextElement)
      {
        TextElement textElement = element as TextElement;
        size = textElement.FontSize;
        ChangeFontSize(endOfApply, size, endingPoint, increase);
      }
      else
      {
        ChangeFontSize(endOfApply, size, endingPoint, increase);
      }

      return; // don't know what to do = done
    }

    private TextPointer SeekEnclosingStartTag(TextPointer point)
    {
      if (null == point)
        return null;

      TextPointerContext ctx = point.GetPointerContext(LogicalDirection.Backward);
      if (TextPointerContext.ElementStart == ctx)
        return point;

      // seek backward...
      return SeekEnclosingStartTag(point.GetNextContextPosition(LogicalDirection.Backward));
    }

    internal void HyperlinkCommandCanExecute(object sender, CanExecuteRoutedEventArgs e)
    {
      e.CanExecute = true;
      e.Handled = true;
    }

    /// <summary>
    /// Extract the selected hyperlink 
    /// </summary>
    /// <returns></returns>
    private Hyperlink ExtractHyperLink()
    {
      RichTextBox rtb = XAMLRichBox;
      if (rtb.Selection.IsEmpty)
        return null;

      TextPointer insertionPosition = rtb.Selection.Start;
      Paragraph paragraph = insertionPosition.Paragraph;
      Hyperlink hyperlink = null;
      TextRange textRange = rtb.Selection;
      foreach (Inline inline in paragraph.Inlines)
      {
        if (inline is Hyperlink)
        {
          hyperlink = (Hyperlink)inline;
          TextRange textRangeHyper = new TextRange(hyperlink.ElementStart, hyperlink.ElementEnd);
          if (textRange.Text == textRangeHyper.Text)
          {
            // here's the link
            break;
          }
          else
          {
            // not the link
            hyperlink = null;
          }
        }
      }

      return hyperlink;
    }

    /// <summary>
    /// Hyperlink Command
    /// </summary>
    /// <param name="target"></param>
    /// <param name="e"></param>
    internal void HyperlinkCommandExecuted(object target, ExecutedRoutedEventArgs e)
    {

      RichTextBox rtb = target as RichTextBox;
      if (rtb.Selection.IsEmpty)
        return;

      // get the hyperlink
      Hyperlink hyperlink = ExtractHyperLink();

      // setup link editor      
      if (null != hyperlink)
      {
        linkEditorText.Text = hyperlink.NavigateUri.ToString();
      }
      else
      {
        linkEditorText.Text = "";
      }

      // show link editor 
      XAMLRichBox.IsReadOnly = true;     
      rtbToolbar.IsEnabled = false;
      linkEditor.Visibility = Visibility.Visible;

      // this is so the highlight stays
      XAMLRichBox.LostFocus += new RoutedEventHandler(delegate(object sender, RoutedEventArgs rea)
      {
        rea.Handled = true;
      });

      XAMLRichBox.SelectionChanged += new RoutedEventHandler(delegate(object sender, RoutedEventArgs rea)
      {
        if (Visibility.Visible == linkEditor.Visibility)
        {
          // back to normal
          XAMLRichBox.IsReadOnly = false;
          rtbToolbar.IsEnabled = true;
          linkEditor.Visibility = Visibility.Collapsed;
        }        
      });
      linkEditor.Focus();
    }

    /// <summary>
    /// Cancel the add hyperlink form
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void OnClickHyperlinkCancel(object sender, RoutedEventArgs e)
    {
      // back to normal
      XAMLRichBox.IsReadOnly = false;
      rtbToolbar.IsEnabled = true;
      linkEditor.Visibility = Visibility.Collapsed;
      XAMLRichBox.Focus();
    }

    /// <summary>
    /// save changes in hyperlink panel
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void OnClickHyperlinkOk(object sender, RoutedEventArgs e)
    {
      RichTextBox rtb = XAMLRichBox as RichTextBox;
      string hyperlinkURL = linkEditorText.Text;
      Hyperlink hyperlink = ExtractHyperLink();

      if (null != hyperlinkURL && 0 < hyperlinkURL.Length)
      {
        try
        {
          var uri = new UriBuilder(hyperlinkURL).Uri;
          if (null == hyperlink)
          {
            // creates the link
            hyperlink = new Hyperlink(rtb.Selection.Start, rtb.Selection.End);
          }

          // set new URL
          hyperlink.NavigateUri = uri;
          hyperlink.TargetName = "_blank";

          // update tooltip
          hyperlink.ToolTip = uri.ToString();
        }
        catch (Exception)
        {
          // NO-OP
        }
      }
      else if (null != hyperlink)
      {
        // old text
        TextRange textRangeHyper = new TextRange(hyperlink.ElementStart, hyperlink.ElementEnd);
        string oldText = textRangeHyper.Text;

        // remove hyperlink
        rtb.Selection.Text = String.Empty;

        // insert plain text in its place
        new Run(oldText, rtb.Selection.Start);
      }

      // back to normal
      XAMLRichBox.IsReadOnly = false;      
      rtbToolbar.IsEnabled = true;
      linkEditor.Visibility = Visibility.Collapsed;
      XAMLRichBox.Focus();
    }

    /// <summary>
    /// Test if the text pointer is in a hyperlink
    /// </summary>
    /// <param name="pos"></param>
    /// <returns></returns>
    private bool searchHyperlink(TextPointer pos)
    {
      if (null == pos)
        return false;

      TextPointerContext context = pos.GetPointerContext(LogicalDirection.Backward);

      if (TextPointerContext.ElementStart == context)
      {
        object elem = pos.GetAdjacentElement(LogicalDirection.Backward);
        if (elem is Hyperlink)
        {
          return true;
        }
      }
      else if (TextPointerContext.ElementEnd == context)
      {
        object elem = pos.GetAdjacentElement(LogicalDirection.Backward);
        if (elem is Hyperlink)
        {
          return false;
        }
      }

      // go backwards...   
      TextPointer back = pos.GetNextContextPosition(LogicalDirection.Backward);
      return searchHyperlink(back);
    }

    public void FontStyleChanged(object sender, SelectionChangedEventArgs args)
    {
      ComboBoxItem lbi = (sender as ComboBox).SelectedItem as ComboBoxItem;
      //tb.Text = "   You selected " + lbi.Content.ToString() + ".";

      //TextRange textRnge = new TextRange(XAMLRichBox.Selection.Start, XAMLRichBox.Selection.End);

      //textRnge.End

      TextPointer selStart = XAMLRichBox.Selection.Start;
      TextPointer selEnd = XAMLRichBox.Selection.End;


      // open dialog
      //InsertHyperlinkWindow win = new InsertHyperlinkWindow();
      //win.ShowDialog();

      if (selStart.IsAtInsertionPosition)
      {
        /* NOOP */
      }
    }

    public void FontSizeChanged(object sender, SelectionChangedEventArgs args)
    {
      ComboBoxItem lbi = (sender as ComboBox).SelectedItem as ComboBoxItem;
      //tb.Text = "   You selected " + lbi.Content.ToString() + ".";

      //TextRange textRnge = new TextRange(XAMLRichBox.Selection.Start, XAMLRichBox.Selection.End);

      //textRnge.End

      TextPointer selStart = XAMLRichBox.Selection.Start;
      TextPointer selEnd = XAMLRichBox.Selection.End;


      // open dialog
      //InsertHyperlinkWindow win = new InsertHyperlinkWindow();
      //win.ShowDialog();

      if (selStart.IsAtInsertionPosition)
      {
        /* NOOP */
      }
    }
  }
}
