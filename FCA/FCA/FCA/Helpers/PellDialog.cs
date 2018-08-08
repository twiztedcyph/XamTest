using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FCA.Helpers
{
    public enum PelDialogButton
    {
        OK,
        Cancel,
        Retry,
        Continue,
        Yes,
        No
    }

    public enum PelDialogType
    {
        Information,
        Error,
        Success,
        Warning,
        Confirm
    }

    public static class PellDialog
    {
        public async static Task DisplayPelAlert(this Page page, PelDialogType type, string message, PelDialogButton button)
        {
            Debug.WriteLine("Display " + type.ToString() + " Dialog : " + message);
            await page.DisplayAlert(type.ToString(), message, button.ToString());
        }

        public async static Task<bool> DisplayYesNoAlert(this Page page, string message)
        {
            bool bYes = await page.DisplayAlert(PelDialogType.Confirm.ToString(), message, PelDialogButton.Yes.ToString(), PelDialogButton.No.ToString());
            Debug.WriteLine("Display " + PelDialogType.Confirm.ToString() + " Dialog : " + message + ". Yes = " + bYes.ToString());
            return bYes;
        }

        public async static Task DisplayError(this Page page, string message)
        {
            await page.DisplayError(message, PelDialogButton.OK);
        }

        public async static Task DisplayError(this Page page, string message, PelDialogButton button)
        {
            await page.DisplayPelAlert(PelDialogType.Error, message, button);
        }

        public async static Task DisplayException(this Page page, string process, Exception ex)
        {
            await page.DisplayPelAlert(PelDialogType.Error, "Something went wrong in " + process + ": " + ex.Message, PelDialogButton.OK);
        }

        public async static Task DisplaySuccess(this Page page, string message)
        {
            await page.DisplaySuccess(message, PelDialogButton.OK);
        }


        public async static Task DisplayInfo(this Page page, string message)
        {
            await page.DisplayPelAlert(PelDialogType.Information, message, PelDialogButton.OK);
        }

        public async static Task DisplaySuccess(this Page page, string message, PelDialogButton button)
        {
            await page.DisplayPelAlert(PelDialogType.Success, message, button);
        }
    }
}
