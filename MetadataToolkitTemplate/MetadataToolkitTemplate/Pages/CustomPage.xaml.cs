using ArcGIS.Desktop.Metadata;
using ArcGIS.Desktop.Metadata.Editor.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace $safeprojectname$.Pages
{

  internal class CustomPageLabel : ISidebarLabel
  {
    string ISidebarLabel.SidebarLabel
    {
      get { return CustomPageLabel.SidebarLabel; }
    }

    public static string SidebarLabel
    {
      get { return "Custom Page"; }
    }
  }
  /// <summary>
  /// Interaction logic for CustomPage.xaml
  /// </summary>
  public partial class CustomPage : EditorPage
  {
    public CustomPage()
    {
      InitializeComponent();
           
    }

    public override string SidebarLabel
    {
      get { return CustomPageLabel.SidebarLabel; }
    }
  }
}
