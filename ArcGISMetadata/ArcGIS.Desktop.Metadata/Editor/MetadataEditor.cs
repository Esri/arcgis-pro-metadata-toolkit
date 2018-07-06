using System;
using System.Windows;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace ArcGIS.Desktop.Metadata
{
  public interface IMetadataEditor
  {
    Type GetType(string pageName);

    string AssemblyLocation { get; }
  }

  public interface IMetadataEditorHost
  {
    string GetCurrentProfile(DependencyObject dep);
    void AddCommitPage(DependencyObject dep);
    void SetIsLoadingPage(DependencyObject dep, bool bLoading);
    void OnUpdateThumbnail(DependencyObject dep);
    void UpdateDataContext(DependencyObject dep);
  }

  public interface ISidebarLabel
  {
    string SidebarLabel
    {
      get;
    }
  }

  public class MetadataEditorBase : IMetadataEditor
  {

    protected Assembly _asm = null;
    public virtual Type GetType(string pageName)
    {
      if (_asm == null)
        _asm = System.Reflection.Assembly.GetAssembly(this.GetType());
      return _asm.GetType(pageName);
    }

    public virtual string AssemblyLocation
    {
      get
      {
        if (_asm == null)
          _asm = System.Reflection.Assembly.GetAssembly(this.GetType());
        return System.IO.Path.GetDirectoryName(
                          Uri.UnescapeDataString(
                                  new Uri(_asm.CodeBase).LocalPath));
      }
    }
  }

  internal class FGDCMetadataEditor : MetadataEditorBase
  {
  }

  internal class InspireMetadataEditor : MetadataEditorBase
  {
  }

  internal class ISO19139Gml32MetadataEditor : MetadataEditorBase
  {
  }

  internal class ISO19139MetadataEditor : MetadataEditorBase
  {
  }

  internal class ItemDescriptionMetadataEditor : MetadataEditorBase
  {
  }

  internal class ISO19115MetadataEditor : MetadataEditorBase
  {
  }
}
