﻿using Microsoft.UI;
using Microsoft.UI.Windowing;
using Microsoft.UI.Xaml;
using System;
using Windows.ApplicationModel;
using Windows.UI;
using WinRT.Interop;
using static Tiles_Media.MainWindow;

namespace Interfaz
{
    public static class BarraTitulo
    {
        public static void Generar(Object ventana)
        {
            if (AppWindowTitleBar.IsCustomizationSupported() == true)
            {
                IntPtr ventanaInt = WindowNative.GetWindowHandle(ventana);
                WindowId ventanaID = Win32Interop.GetWindowIdFromWindow(ventanaInt);
                
                AppWindow ventanaTitulo = AppWindow.GetFromWindowId(ventanaID);
                ventanaTitulo.TitleBar.ExtendsContentIntoTitleBar = true;
                ventanaTitulo.TitleBar.ButtonBackgroundColor = Colors.Transparent;
                ventanaTitulo.TitleBar.ButtonHoverBackgroundColor = (Color)Application.Current.Resources["ColorPrimario"];
                ventanaTitulo.TitleBar.ButtonInactiveBackgroundColor = Colors.Transparent;
                ventanaTitulo.TitleBar.ButtonForegroundColor = (Color)Application.Current.Resources["ColorFuente"];
                ventanaTitulo.TitleBar.ButtonInactiveForegroundColor = (Color)Application.Current.Resources["ColorFuente"];
            }
        }

        public static void CambiarTitulo(string titulo)
        {
            Objetos.ventana.Title = Package.Current.DisplayName;
            Objetos.tbTitulo.Text = Package.Current.DisplayName + " (" + Package.Current.Id.Version.Major.ToString() + "." + Package.Current.Id.Version.Minor.ToString() + "." + Package.Current.Id.Version.Build.ToString() + "." + Package.Current.Id.Version.Revision.ToString() + ")";

            if (titulo != null)
            {
                if (titulo.Trim().Length > 0)
                {
                    Objetos.tbTitulo.Text = Objetos.tbTitulo.Text + " • " + titulo;
                }              
            }
        }
    }
}
