﻿namespace ArcGIS.Desktop.Internal.Metadata.Properties {


  // This class allows you to handle specific events on the settings class:
  //  The SettingChanging event is raised before a setting's value is changed.
  //  The PropertyChanged event is raised after a setting's value is changed.
  //  The SettingsLoaded event is raised after the setting values are loaded.
  //  The SettingsSaving event is raised before the setting values are saved.
  internal sealed partial class Settings
  {
    public Settings()
    {
      if (UpgradeNeeded == true)
      {
        UpgradeNeeded = false;
        Save();
        Upgrade();
      }
    }


    private void SettingChangingEventHandler(object sender, System.Configuration.SettingChangingEventArgs e)
    {
      // Add code to handle the SettingChangingEvent event here.
    }

    private void SettingsSavingEventHandler(object sender, System.ComponentModel.CancelEventArgs e)
    {
      // Add code to handle the SettingsSaving event here.
    }
  }
}

