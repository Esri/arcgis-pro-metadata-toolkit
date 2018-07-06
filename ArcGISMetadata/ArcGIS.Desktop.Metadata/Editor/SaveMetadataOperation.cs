/*
COPYRIGHT 2013-2016 ESRI

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
using System.Threading.Tasks;

using ArcGIS.Desktop.Framework.Contracts;
using ArcGIS.Desktop.Metadata.Editor;
using ESRI.ArcGIS.ItemIndex;

namespace ArcGIS.Desktop.Internal.Metadata
{
  internal class SaveMetadataOperation : Operation
  {
    private int _repositoryID = -1;
    MetadataEditorViewModel _editorVM = null;
    private string _name = string.Empty;
    private string _currentMetadata = string.Empty;
    private string _originalMetadata = string.Empty;
    private bool _bSaved = false;  // If saved, then it is redo

    public SaveMetadataOperation(int repositoryID, MetadataEditorViewModel vm)
    {
      _repositoryID = repositoryID;
      _editorVM = vm;
      _name = _editorVM.Item.Name; ;
      _currentMetadata = _editorVM.CurrentMetadata;
      _originalMetadata = _editorVM.OriginalMetadata;
    }

    public override string Name
    {
      get { return string.Format(Internal.Metadata.Properties.Resources.SaveMetadataOperationName, _name); }
    }

    public override string Category
    {
      get { return Internal.Metadata.Properties.Resources.CategoryMetadata; }
    }

    protected async override Task DoAsync()
    {
      await _editorVM.CommitMetadataAsync(_bSaved, _currentMetadata);

      if (!_bSaved)
        _bSaved = true;
    }

    protected async override Task UndoAsync()
    {
      await _editorVM.CommitOriginalMetadataAsync(_originalMetadata);
    }

    protected override Task RedoAsync()
    {
      return DoAsync();
    }

    public override bool CanRedo
    {
      get { return IsOperationStillValid; }
    }

    public override bool CanUndo
    {
      get { return IsOperationStillValid; }
    }

    private bool IsOperationStillValid
    {
      get { return true; }
    }
  }
}
