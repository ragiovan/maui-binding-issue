namespace CellularSignal1;

#if ANDROID

using Android.Content;
using Android.OS;
using Android.Telephony;
using Microsoft.Maui.Controls.Internals;
using System.Collections.Generic;

public static class Permission
{
    public static PermissionStatus LocationPermission = PermissionStatus.Unknown;

    public static async Task<PermissionStatus> CheckAndRequestLocationPermission()
    {
        try
        {
            LocationPermission = await Permissions.CheckStatusAsync<Permissions.LocationWhenInUse>();

            if (LocationPermission == PermissionStatus.Granted)
                return LocationPermission;

            if (Permissions.ShouldShowRationale<Permissions.LocationWhenInUse>())
            {
                await Shell.Current.DisplayAlert("Needs Permissions", "Location is required in order to obtain signal information from base station. Please enable this for the app to work properly.", "OK");
            }

            LocationPermission = await Permissions.RequestAsync<Permissions.LocationWhenInUse>();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            await Shell.Current.DisplayAlert("Error", "Error when getting permissions. Please send us a message so we can fix this!", "OK");
        }

        return LocationPermission;
    }

}

#endif
