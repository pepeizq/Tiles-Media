using CommunityToolkit.WinUI.Notifications;
using CommunityToolkit.WinUI.UI.Controls;
using FontAwesome6;
using Herramientas;
using Microsoft.UI;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Media.Imaging;
using Microsoft.VisualBasic;
using System;
using Windows.UI;
using Windows.UI.Notifications;
using Windows.UI.StartScreen;
using WinRT.Interop;
using static Tiles_Media.MainWindow;

namespace Interfaz
{
    public static class Tiles
    {
        public static void Cargar()
        {
            int i = 0;
            foreach (Button2 boton in Objetos.spTilesBotones.Children)
            {
                boton.Tag = i;
                boton.Click += CambiarPestaña;
                boton.PointerEntered += Animaciones.EntraRatonBoton2;
                boton.PointerExited += Animaciones.SaleRatonBoton2;

                i += 1;
            }

            CambiarPestaña(0);

            //---------------------------------

            Objetos.tbTilesPrecargaImagenPequeña.TextChanged += ActualizarImagenPequeña;
            Objetos.tbTilesPrecargaImagenMediana.TextChanged += ActualizarImagenMediana;
            Objetos.tbTilesPrecargaImagenAncha.TextChanged += ActualizarImagenAncha;
            Objetos.tbTilesPrecargaImagenGrande.TextChanged += ActualizarImagenGrande;

            Objetos.imagenTilesPrecargaPequeña.ImageOpened += ImagenPequeñaCarga;
            Objetos.imagenTilesPrecargaPequeña.ImageFailed += ImagenPequeñaFalla;
            Objetos.imagenTilesPrecargaMediana.ImageOpened += ImagenMedianaCarga;
            Objetos.imagenTilesPrecargaMediana.ImageFailed += ImagenMedianaFalla;
            Objetos.imagenTilesPrecargaAncha.ImageOpened += ImagenAnchaCarga;
            Objetos.imagenTilesPrecargaAncha.ImageFailed += ImagenAnchaFalla;
            Objetos.imagenTilesPrecargaGrande.ImageOpened += ImagenGrandeCarga;
            Objetos.imagenTilesPrecargaGrande.ImageFailed += ImagenGrandeFalla;

            Objetos.cbTilesPrecargaPequeñaEstiramiento.SelectionChanged += EstiramientoPequeñaCambio;
            Objetos.cbTilesPrecargaPequeñaEstiramiento.PointerEntered += Animaciones.EntraRatonComboCaja2;
            Objetos.cbTilesPrecargaPequeñaEstiramiento.PointerExited += Animaciones.SaleRatonComboCaja2;
            Objetos.cbTilesPrecargaMedianaEstiramiento.SelectionChanged += EstiramientoMedianaCambio;
            Objetos.cbTilesPrecargaMedianaEstiramiento.PointerEntered += Animaciones.EntraRatonComboCaja2;
            Objetos.cbTilesPrecargaMedianaEstiramiento.PointerExited += Animaciones.SaleRatonComboCaja2;
            Objetos.cbTilesPrecargaAnchaEstiramiento.SelectionChanged += EstiramientoAnchaCambio;
            Objetos.cbTilesPrecargaAnchaEstiramiento.PointerEntered += Animaciones.EntraRatonComboCaja2;
            Objetos.cbTilesPrecargaAnchaEstiramiento.PointerExited += Animaciones.SaleRatonComboCaja2;
            Objetos.cbTilesPrecargaGrandeEstiramiento.SelectionChanged += EstiramientoGrandeCambio;
            Objetos.cbTilesPrecargaGrandeEstiramiento.PointerEntered += Animaciones.EntraRatonComboCaja2;
            Objetos.cbTilesPrecargaGrandeEstiramiento.PointerExited += Animaciones.SaleRatonComboCaja2;

            Objetos.cbTilesPrecargaPequeñaOrientacionHorizontal.SelectionChanged += OrientacionHorizontalPequeñaCambio;
            Objetos.cbTilesPrecargaPequeñaOrientacionHorizontal.PointerEntered += Animaciones.EntraRatonComboCaja2;
            Objetos.cbTilesPrecargaPequeñaOrientacionHorizontal.PointerExited += Animaciones.SaleRatonComboCaja2;
            Objetos.cbTilesPrecargaMedianaOrientacionHorizontal.SelectionChanged += OrientacionHorizontalMedianaCambio;
            Objetos.cbTilesPrecargaMedianaOrientacionHorizontal.PointerEntered += Animaciones.EntraRatonComboCaja2;
            Objetos.cbTilesPrecargaMedianaOrientacionHorizontal.PointerExited += Animaciones.SaleRatonComboCaja2;
            Objetos.cbTilesPrecargaAnchaOrientacionHorizontal.SelectionChanged += OrientacionHorizontalAnchaCambio;
            Objetos.cbTilesPrecargaAnchaOrientacionHorizontal.PointerEntered += Animaciones.EntraRatonComboCaja2;
            Objetos.cbTilesPrecargaAnchaOrientacionHorizontal.PointerExited += Animaciones.SaleRatonComboCaja2;
            Objetos.cbTilesPrecargaGrandeOrientacionHorizontal.SelectionChanged += OrientacionHorizontalGrandeCambio;
            Objetos.cbTilesPrecargaGrandeOrientacionHorizontal.PointerEntered += Animaciones.EntraRatonComboCaja2;
            Objetos.cbTilesPrecargaGrandeOrientacionHorizontal.PointerExited += Animaciones.SaleRatonComboCaja2;

            Objetos.cbTilesPrecargaPequeñaOrientacionVertical.SelectionChanged += OrientacionVerticalPequeñaCambio;
            Objetos.cbTilesPrecargaPequeñaOrientacionVertical.PointerEntered += Animaciones.EntraRatonComboCaja2;
            Objetos.cbTilesPrecargaPequeñaOrientacionVertical.PointerExited += Animaciones.SaleRatonComboCaja2;
            Objetos.cbTilesPrecargaMedianaOrientacionVertical.SelectionChanged += OrientacionVerticalMedianaCambio;
            Objetos.cbTilesPrecargaMedianaOrientacionVertical.PointerEntered += Animaciones.EntraRatonComboCaja2;
            Objetos.cbTilesPrecargaMedianaOrientacionVertical.PointerExited += Animaciones.SaleRatonComboCaja2;
            Objetos.cbTilesPrecargaAnchaOrientacionVertical.SelectionChanged += OrientacionVerticalAnchaCambio;
            Objetos.cbTilesPrecargaAnchaOrientacionVertical.PointerEntered += Animaciones.EntraRatonComboCaja2;
            Objetos.cbTilesPrecargaAnchaOrientacionVertical.PointerExited += Animaciones.SaleRatonComboCaja2;
            Objetos.cbTilesPrecargaGrandeOrientacionVertical.SelectionChanged += OrientacionVerticalGrandeCambio;
            Objetos.cbTilesPrecargaGrandeOrientacionVertical.PointerEntered += Animaciones.EntraRatonComboCaja2;
            Objetos.cbTilesPrecargaGrandeOrientacionVertical.PointerExited += Animaciones.SaleRatonComboCaja2;

            Objetos.botonTilesCargarJuego.Click += CargarJuego;
            Objetos.botonTilesCargarJuego.PointerEntered += Animaciones.EntraRatonBoton2;
            Objetos.botonTilesCargarJuego.PointerExited += Animaciones.SaleRatonBoton2;
        }

        private static void CambiarPestaña(object sender, RoutedEventArgs e)
        {
            Button2 botonPulsado = sender as Button2;
            int pestañaMostrar = (int)botonPulsado.Tag;
            CambiarPestaña(pestañaMostrar);
        }

        private static void CambiarPestaña(int botonPulsado)
        {
            SolidColorBrush colorPulsado = new SolidColorBrush((Color)Application.Current.Resources["ColorPrimario"]);
            colorPulsado.Opacity = 0.6;

            int i = 0;
            foreach (Button2 boton in Objetos.spTilesBotones.Children)
            {
                if (i == botonPulsado)
                {
                    boton.Background = colorPulsado;
                }
                else
                {
                    boton.Background = new SolidColorBrush(Colors.Transparent);
                }

                i += 1;
            }

            foreach (StackPanel sp in Objetos.spTilesPestañas.Children)
            {
                sp.Visibility = Visibility.Collapsed;
            }

            StackPanel spMostrar = Objetos.spTilesPestañas.Children[botonPulsado] as StackPanel;
            spMostrar.Visibility = Visibility.Visible;
        }
        private static void ActualizarImagenPequeña(object sender, TextChangedEventArgs e)
        {
            TextBox tb = sender as TextBox;

            try
            {
                Objetos.imagenTilesPrecargaPequeña.Source = new BitmapImage(new Uri(tb.Text));
                Objetos.imagenTilesPrecargaPequeña2.Source = new BitmapImage(new Uri(tb.Text));
            }
            catch { }
        }

        private static void ActualizarImagenMediana(object sender, TextChangedEventArgs e)
        {
            TextBox tb = sender as TextBox;

            try
            {
                Objetos.imagenTilesPrecargaMediana.Source = new BitmapImage(new Uri(tb.Text));
                Objetos.imagenTilesPrecargaMediana2.Source = new BitmapImage(new Uri(tb.Text));
            }
            catch { }
        }

        private static void ActualizarImagenAncha(object sender, TextChangedEventArgs e)
        {
            TextBox tb = sender as TextBox;

            try
            {
                Objetos.imagenTilesPrecargaAncha.Source = new BitmapImage(new Uri(tb.Text));
                Objetos.imagenTilesPrecargaAncha2.Source = new BitmapImage(new Uri(tb.Text));
            }
            catch { }           
        }

        private static void ActualizarImagenGrande(object sender, TextChangedEventArgs e)
        {
            TextBox tb = sender as TextBox;

            try
            {
                Objetos.imagenTilesPrecargaGrande.Source = new BitmapImage(new Uri(tb.Text));
                Objetos.imagenTilesPrecargaGrande2.Source = new BitmapImage(new Uri(tb.Text));
            }
            catch { }
        }

        private static void ImagenPequeñaCarga(object sender, RoutedEventArgs e)
        {
            Objetos.iconoTilesPrecargaPequeña.Icon = EFontAwesomeIcon.Solid_Check;
        }

        private static void ImagenPequeñaFalla(object sender, ExceptionRoutedEventArgs e) 
        {
            ImageEx imagen = sender as ImageEx;

            try
            {
                imagen.Source = null;
            }
            catch { }

            try
            {
                Objetos.tbTilesPrecargaImagenPequeña.Text = null;
            }
            catch { }

            Objetos.iconoTilesPrecargaPequeña.Icon = EFontAwesomeIcon.Solid_Xmark;
        }

        private static void ImagenMedianaCarga(object sender, RoutedEventArgs e)
        {
            Objetos.iconoTilesPrecargaMediana.Icon = EFontAwesomeIcon.Solid_Check;
        }

        private static void ImagenMedianaFalla(object sender, ExceptionRoutedEventArgs e)
        {
            ImageEx imagen = sender as ImageEx;

            try
            {
                imagen.Source = null;
            }
            catch { }

            try
            {
                Objetos.tbTilesPrecargaImagenMediana.Text = null;
            }
            catch { }

            Objetos.iconoTilesPrecargaMediana.Icon = EFontAwesomeIcon.Solid_Xmark;
        }

        private static void ImagenAnchaCarga(object sender, RoutedEventArgs e)
        {
            Objetos.iconoTilesPrecargaAncha.Icon = EFontAwesomeIcon.Solid_Check;
        }

        private static void ImagenAnchaFalla(object sender, ExceptionRoutedEventArgs e)
        {
            ImageEx imagen = sender as ImageEx;

            try
            {
                imagen.Source = null;
            }
            catch { }

            try
            {
                Objetos.tbTilesPrecargaImagenAncha.Text = null;
            }
            catch { }

            Objetos.iconoTilesPrecargaAncha.Icon = EFontAwesomeIcon.Solid_Xmark;
        }

        private static void ImagenGrandeCarga(object sender, RoutedEventArgs e)
        {
            Objetos.iconoTilesPrecargaGrande.Icon = EFontAwesomeIcon.Solid_Check;
        }

        private static void ImagenGrandeFalla(object sender, ExceptionRoutedEventArgs e)
        {
            ImageEx imagen = sender as ImageEx;

            try
            {
                imagen.Source = null;
            }
            catch { }

            try
            {
                Objetos.tbTilesPrecargaImagenGrande.Text = null;
            }
            catch { }

            Objetos.iconoTilesPrecargaGrande.Icon = EFontAwesomeIcon.Solid_Xmark;
        }

        private static void EstiramientoPequeñaCambio(object sender, SelectionChangedEventArgs e)
        {
            ComboBox2 cb = sender as ComboBox2;
            EstiramientoImagen(cb, Objetos.imagenTilesPrecargaPequeña, Objetos.imagenTilesPrecargaPequeña2);
        }

        private static void EstiramientoMedianaCambio(object sender, SelectionChangedEventArgs e)
        {
            ComboBox2 cb = sender as ComboBox2;
            EstiramientoImagen(cb, Objetos.imagenTilesPrecargaMediana, Objetos.imagenTilesPrecargaMediana2);
        }

        private static void EstiramientoAnchaCambio(object sender, SelectionChangedEventArgs e)
        {
            ComboBox2 cb = sender as ComboBox2;
            EstiramientoImagen(cb, Objetos.imagenTilesPrecargaAncha, Objetos.imagenTilesPrecargaAncha2);
        }

        private static void EstiramientoGrandeCambio(object sender, SelectionChangedEventArgs e)
        {
            ComboBox2 cb = sender as ComboBox2;
            EstiramientoImagen(cb, Objetos.imagenTilesPrecargaGrande, Objetos.imagenTilesPrecargaGrande2);
        }

        private static void EstiramientoImagen(ComboBox2 cb, Image imagen1, Image imagen2)
        {
            if (cb.SelectedIndex == 0)
            {
                imagen1.Stretch = Stretch.None;
                imagen2.Stretch = Stretch.None;
            }
            else if (cb.SelectedIndex == 1)
            {
                imagen1.Stretch = Stretch.Fill;
                imagen2.Stretch = Stretch.Fill;
            }
            else if (cb.SelectedIndex == 2)
            {
                imagen1.Stretch = Stretch.Uniform;
                imagen2.Stretch = Stretch.Uniform;
            }
            else if (cb.SelectedIndex == 3)
            {
                imagen1.Stretch = Stretch.UniformToFill;
                imagen2.Stretch = Stretch.UniformToFill;
            }
        }

        private static void OrientacionHorizontalPequeñaCambio(object sender, SelectionChangedEventArgs e)
        {
            ComboBox2 cb = sender as ComboBox2;
            OrientacionHorizontalImagen(cb, Objetos.imagenTilesPrecargaPequeña, Objetos.imagenTilesPrecargaPequeña2);
        }

        private static void OrientacionHorizontalMedianaCambio(object sender, SelectionChangedEventArgs e)
        {
            ComboBox2 cb = sender as ComboBox2;
            OrientacionHorizontalImagen(cb, Objetos.imagenTilesPrecargaMediana, Objetos.imagenTilesPrecargaMediana2);
        }

        private static void OrientacionHorizontalAnchaCambio(object sender, SelectionChangedEventArgs e)
        {
            ComboBox2 cb = sender as ComboBox2;
            OrientacionHorizontalImagen(cb, Objetos.imagenTilesPrecargaAncha, Objetos.imagenTilesPrecargaAncha2);
        }

        private static void OrientacionHorizontalGrandeCambio(object sender, SelectionChangedEventArgs e)
        {
            ComboBox2 cb = sender as ComboBox2;
            OrientacionHorizontalImagen(cb, Objetos.imagenTilesPrecargaGrande, Objetos.imagenTilesPrecargaGrande2);
        }

        private static void OrientacionHorizontalImagen(ComboBox2 cb, Image imagen1, Image imagen2)
        {
            if (cb.SelectedIndex == 0)
            {
                imagen1.HorizontalAlignment = HorizontalAlignment.Left;
                imagen2.HorizontalAlignment = HorizontalAlignment.Left;
            }
            else if (cb.SelectedIndex == 1)
            {
                imagen1.HorizontalAlignment = HorizontalAlignment.Center;
                imagen2.HorizontalAlignment = HorizontalAlignment.Center;
            }
            else if (cb.SelectedIndex == 2)
            {
                imagen1.HorizontalAlignment = HorizontalAlignment.Right;
                imagen2.HorizontalAlignment = HorizontalAlignment.Right;
            }
            else if (cb.SelectedIndex == 3)
            {
                imagen1.HorizontalAlignment = HorizontalAlignment.Stretch;
                imagen2.HorizontalAlignment = HorizontalAlignment.Stretch;
            }
        }

        private static void OrientacionVerticalPequeñaCambio(object sender, SelectionChangedEventArgs e)
        {
            ComboBox2 cb = sender as ComboBox2;
            OrientacionVerticalImagen(cb, Objetos.imagenTilesPrecargaPequeña, Objetos.imagenTilesPrecargaPequeña2);
        }

        private static void OrientacionVerticalMedianaCambio(object sender, SelectionChangedEventArgs e)
        {
            ComboBox2 cb = sender as ComboBox2;
            OrientacionVerticalImagen(cb, Objetos.imagenTilesPrecargaMediana, Objetos.imagenTilesPrecargaMediana2);
        }

        private static void OrientacionVerticalAnchaCambio(object sender, SelectionChangedEventArgs e)
        {
            ComboBox2 cb = sender as ComboBox2;
            OrientacionVerticalImagen(cb, Objetos.imagenTilesPrecargaAncha, Objetos.imagenTilesPrecargaAncha2);
        }

        private static void OrientacionVerticalGrandeCambio(object sender, SelectionChangedEventArgs e)
        {
            ComboBox2 cb = sender as ComboBox2;
            OrientacionVerticalImagen(cb, Objetos.imagenTilesPrecargaGrande, Objetos.imagenTilesPrecargaGrande2);
        }

        private static void OrientacionVerticalImagen(ComboBox2 cb, Image imagen1, Image imagen2)
        {
            if (cb.SelectedIndex == 0)
            {
                imagen1.VerticalAlignment = VerticalAlignment.Top;
                imagen2.VerticalAlignment = VerticalAlignment.Top;
            }
            else if (cb.SelectedIndex == 1)
            {
                imagen1.VerticalAlignment = VerticalAlignment.Center;
                imagen2.VerticalAlignment = VerticalAlignment.Center;
            }
            else if (cb.SelectedIndex == 2)
            {
                imagen1.VerticalAlignment = VerticalAlignment.Bottom;
                imagen2.VerticalAlignment = VerticalAlignment.Bottom;
            }
            else if (cb.SelectedIndex == 3)
            {
                imagen1.VerticalAlignment = VerticalAlignment.Stretch;
                imagen2.VerticalAlignment = VerticalAlignment.Stretch;
            }
        }

        public static void PrecargarMedia(string nombre, string ejecutable, string id, string imagenAncha, string imagenGrande)
        {
            ActivarDesactivar(false);

            Pestañas.Visibilidad(Objetos.gridTilesPrecarga, true, null, false);
            BarraTitulo.CambiarTitulo(null);

            //-------------------------------------------------

            Objetos.iconoTilesPrecargaPequeña.Icon = EFontAwesomeIcon.Solid_Xmark;
            Objetos.iconoTilesPrecargaMediana.Icon = EFontAwesomeIcon.Solid_Xmark;
            Objetos.iconoTilesPrecargaAncha.Icon = EFontAwesomeIcon.Solid_Xmark;
            Objetos.iconoTilesPrecargaGrande.Icon = EFontAwesomeIcon.Solid_Xmark;

            Objetos.tbTilesPrecargaTitulo.Text = null;
            Objetos.tbTilesPrecargaEjecutable.Text = null;
            Objetos.tbTilesPrecargaImagenPequeña.Text = null; 
            Objetos.tbTilesPrecargaImagenMediana.Text = null;
            Objetos.tbTilesPrecargaImagenAncha.Text = null;
            Objetos.tbTilesPrecargaImagenGrande.Text = null;
            Objetos.imagenTilesPrecargaPequeña.Source = null;
            Objetos.imagenTilesPrecargaMediana.Source = null;
            Objetos.imagenTilesPrecargaAncha.Source = null;
            Objetos.imagenTilesPrecargaGrande.Source = null;
            Objetos.imagenTilesPrecargaPequeña2.Source = null;
            Objetos.imagenTilesPrecargaMediana2.Source = null;
            Objetos.imagenTilesPrecargaAncha2.Source = null;
            Objetos.imagenTilesPrecargaGrande2.Source = null;

            //-------------------------------------------------

            Objetos.tbTilesPrecargaTitulo.Tag = id;

            Objetos.tbTilesPrecargaTitulo.Text = nombre;
            Objetos.tbTilesPrecargaEjecutable.Text = ejecutable;

            Objetos.tbTilesPrecargaImagenPequeña.Text = imagenAncha;
            Objetos.tbTilesPrecargaImagenMediana.Text = imagenAncha;
            Objetos.tbTilesPrecargaImagenAncha.Text = imagenAncha;
            Objetos.tbTilesPrecargaImagenGrande.Text = imagenGrande;

            if (Objetos.tbTilesPrecargaImagenMediana.Text != string.Empty)
            {
                try
                {
                    Objetos.imagenTilesPrecargaPequeña.Source = new BitmapImage(new Uri(Objetos.tbTilesPrecargaImagenPequeña.Text));
                    Objetos.imagenTilesPrecargaPequeña2.Source = new BitmapImage(new Uri(Objetos.tbTilesPrecargaImagenPequeña.Text));
                }
                catch { }
            }

            if (Objetos.tbTilesPrecargaImagenMediana.Text != string.Empty)
            {
                try
                {
                    Objetos.imagenTilesPrecargaMediana.Source = new BitmapImage(new Uri(Objetos.tbTilesPrecargaImagenMediana.Text));
                    Objetos.imagenTilesPrecargaMediana2.Source = new BitmapImage(new Uri(Objetos.tbTilesPrecargaImagenMediana.Text));
                }
                catch { }
            }

            if (Objetos.tbTilesPrecargaImagenAncha.Text != string.Empty)
            {
                try
                {
                    Objetos.imagenTilesPrecargaAncha.Source = new BitmapImage(new Uri(Objetos.tbTilesPrecargaImagenAncha.Text));
                    Objetos.imagenTilesPrecargaAncha2.Source = new BitmapImage(new Uri(Objetos.tbTilesPrecargaImagenAncha.Text));
                }
                catch { }
            }

            if (Objetos.tbTilesPrecargaImagenGrande.Text != string.Empty)
            {
                try
                {
                    Objetos.imagenTilesPrecargaGrande.Source = new BitmapImage(new Uri(Objetos.tbTilesPrecargaImagenGrande.Text));
                    Objetos.imagenTilesPrecargaGrande2.Source = new BitmapImage(new Uri(Objetos.tbTilesPrecargaImagenGrande.Text));
                }
                catch { }
            }

            //-------------------------------------------------

            Objetos.cbTilesPrecargaPequeñaEstiramiento.SelectedIndex = 2;
            Objetos.imagenTilesPrecargaPequeña.Stretch = Stretch.Uniform;
            Objetos.imagenTilesPrecargaPequeña2.Stretch = Stretch.Uniform;

            Objetos.cbTilesPrecargaMedianaEstiramiento.SelectedIndex = 2;
            Objetos.imagenTilesPrecargaMediana.Stretch = Stretch.Uniform;
            Objetos.imagenTilesPrecargaMediana2.Stretch = Stretch.Uniform;

            Objetos.cbTilesPrecargaAnchaEstiramiento.SelectedIndex = 3;
            Objetos.imagenTilesPrecargaAncha.Stretch = Stretch.UniformToFill;
            Objetos.imagenTilesPrecargaAncha2.Stretch = Stretch.UniformToFill;

            Objetos.cbTilesPrecargaGrandeEstiramiento.SelectedIndex = 2;
            Objetos.imagenTilesPrecargaGrande.Stretch = Stretch.Uniform;
            Objetos.imagenTilesPrecargaGrande2.Stretch = Stretch.Uniform;

            //-------------------------------------------------

            Objetos.cbTilesPrecargaPequeñaOrientacionHorizontal.SelectedIndex = 3;
            Objetos.imagenTilesPrecargaPequeña.HorizontalAlignment = HorizontalAlignment.Stretch;
            Objetos.imagenTilesPrecargaPequeña2.HorizontalAlignment = HorizontalAlignment.Stretch;

            Objetos.cbTilesPrecargaMedianaOrientacionHorizontal.SelectedIndex = 3;
            Objetos.imagenTilesPrecargaMediana.HorizontalAlignment = HorizontalAlignment.Stretch;
            Objetos.imagenTilesPrecargaMediana2.HorizontalAlignment = HorizontalAlignment.Stretch;

            Objetos.cbTilesPrecargaAnchaOrientacionHorizontal.SelectedIndex = 3;
            Objetos.imagenTilesPrecargaAncha.HorizontalAlignment = HorizontalAlignment.Stretch;
            Objetos.imagenTilesPrecargaAncha2.HorizontalAlignment = HorizontalAlignment.Stretch;

            Objetos.cbTilesPrecargaGrandeOrientacionHorizontal.SelectedIndex = 3;
            Objetos.imagenTilesPrecargaGrande.HorizontalAlignment = HorizontalAlignment.Stretch;
            Objetos.imagenTilesPrecargaGrande2.HorizontalAlignment = HorizontalAlignment.Stretch;

            //-------------------------------------------------

            Objetos.cbTilesPrecargaPequeñaOrientacionVertical.SelectedIndex = 3;
            Objetos.imagenTilesPrecargaPequeña.VerticalAlignment = VerticalAlignment.Stretch;
            Objetos.imagenTilesPrecargaPequeña2.VerticalAlignment = VerticalAlignment.Stretch;

            Objetos.cbTilesPrecargaMedianaOrientacionVertical.SelectedIndex = 3;
            Objetos.imagenTilesPrecargaMediana.VerticalAlignment = VerticalAlignment.Stretch;
            Objetos.imagenTilesPrecargaMediana2.VerticalAlignment = VerticalAlignment.Stretch;

            Objetos.cbTilesPrecargaAnchaOrientacionVertical.SelectedIndex = 3;
            Objetos.imagenTilesPrecargaAncha.VerticalAlignment = VerticalAlignment.Stretch;
            Objetos.imagenTilesPrecargaAncha2.VerticalAlignment = VerticalAlignment.Stretch;

            Objetos.cbTilesPrecargaGrandeOrientacionVertical.SelectedIndex = 3;
            Objetos.imagenTilesPrecargaGrande.VerticalAlignment = VerticalAlignment.Stretch;
            Objetos.imagenTilesPrecargaGrande2.VerticalAlignment = VerticalAlignment.Stretch;

            ActivarDesactivar(true);
        }

        public static async void CargarJuego(object sender, RoutedEventArgs e)
        {
            ActivarDesactivar(false);

            string id = Objetos.tbTilesPrecargaTitulo.Tag as string;

            await Imagen.Generar(Objetos.gridTilesPrecargaImagenPequeña, id + "pequena.png", 44, 44);
            await Imagen.Generar(Objetos.gridTilesPrecargaImagenMediana, id + "mediana.png", 150, 150);
            await Imagen.Generar(Objetos.gridTilesPrecargaImagenAncha, id + "ancha.png", 310, 150);
            await Imagen.Generar(Objetos.gridTilesPrecargaImagenGrande, id + "grande.png", 310, 310);

            string titulo = Objetos.tbTilesPrecargaTitulo.Text;
            string enlace = Objetos.tbTilesPrecargaEjecutable.Text;

            SecondaryTile nuevaTile = new SecondaryTile(id, titulo, enlace, new Uri("ms-appdata:///local/" + id + "ancha.png"), Windows.UI.StartScreen.TileSize.Wide310x150);
            nuevaTile.VisualElements.Square44x44Logo = new Uri("ms-appdata:///local/" + id + "pequena.png");
            nuevaTile.VisualElements.Square30x30Logo = new Uri("ms-appdata:///local/" + id + "pequena.png");
            nuevaTile.VisualElements.Square70x70Logo = new Uri("ms-appdata:///local/" + id + "pequena.png");
            nuevaTile.VisualElements.Square71x71Logo = new Uri("ms-appdata:///local/" + id + "pequena.png");
            nuevaTile.VisualElements.Square150x150Logo = new Uri("ms-appdata:///local/" + id + "mediana.png");
            nuevaTile.VisualElements.Wide310x150Logo = new Uri("ms-appdata:///local/" + id + "ancha.png");
            nuevaTile.VisualElements.Square310x310Logo = new Uri("ms-appdata:///local/" + id + "grande.png");
  
            InitializeWithWindow.Initialize(nuevaTile, WindowNative.GetWindowHandle(Objetos.ventana));

            await nuevaTile.RequestCreateAsync();

            //-----------------------------------------------

            TileBindingContentAdaptive contenidoMediano = new TileBindingContentAdaptive();

            TileBackgroundImage fondoImagenMediano = new TileBackgroundImage
            {
                Source = "ms-appdata:///local/" + id + "mediana.png",
                HintCrop = (TileBackgroundImageCrop)AdaptiveImageCrop.Default
            };

            contenidoMediano = new TileBindingContentAdaptive
            {
                BackgroundImage = fondoImagenMediano
            };

            TileBinding tileMediano = new TileBinding {
                Content = contenidoMediano
            };

            //-----------------------------------------------

            TileBindingContentAdaptive contenidoAncho = new TileBindingContentAdaptive();

            TileBackgroundImage fondoImagenAncha = new TileBackgroundImage 
            {
                Source = "ms-appdata:///local/" + id + "ancha.png",
                HintCrop = (TileBackgroundImageCrop)AdaptiveImageCrop.Default
            };

            contenidoAncho = new TileBindingContentAdaptive 
            {
                BackgroundImage = fondoImagenAncha
            };

            TileBinding tileAncha = new TileBinding 
            {
                Content = contenidoAncho
            };

            //-----------------------------------------------

            TileBindingContentAdaptive contenidoGrande = new TileBindingContentAdaptive();

            TileBackgroundImage fondoImagenGrande = new TileBackgroundImage 
            {
                Source = "ms-appdata:///local/" + id + "grande.png",
                HintCrop = (TileBackgroundImageCrop)AdaptiveImageCrop.Default
            };

            contenidoGrande = new TileBindingContentAdaptive 
            {
                BackgroundImage = fondoImagenGrande
            };

            TileBinding tileGrande = new TileBinding 
            {
                Content = contenidoGrande
            };

            //-----------------------------------------------

            TileVisual visual = new TileVisual
            {
                TileMedium = tileMediano,
                TileWide = tileAncha,
                TileLarge = tileGrande
            };

            TileContent contenido = new TileContent
            {
                Visual = visual
            };

            TileNotification notificacion = new TileNotification(contenido.GetXml());

            try
            {
                TileUpdateManager.CreateTileUpdaterForSecondaryTile(id).Update(notificacion);
            }
            catch { }

            ActivarDesactivar(true);
        }

        private static void ActivarDesactivar(bool estado)
        {
            Objetos.tbTilesPrecargaTitulo.IsEnabled = estado;
            Objetos.tbTilesPrecargaEjecutable.IsEnabled = estado;

            Objetos.tbTilesPrecargaImagenPequeña.IsEnabled = estado;
            Objetos.tbTilesPrecargaImagenMediana.IsEnabled = estado;
            Objetos.tbTilesPrecargaImagenAncha.IsEnabled = estado;
            Objetos.tbTilesPrecargaImagenGrande.IsEnabled = estado;

            Objetos.cbTilesPrecargaPequeñaEstiramiento.IsEnabled = estado;
            Objetos.cbTilesPrecargaMedianaEstiramiento.IsEnabled = estado;
            Objetos.cbTilesPrecargaAnchaEstiramiento.IsEnabled = estado;
            Objetos.cbTilesPrecargaGrandeEstiramiento.IsEnabled = estado;
            Objetos.cbTilesPrecargaPequeñaOrientacionHorizontal.IsEnabled = estado;
            Objetos.cbTilesPrecargaMedianaOrientacionHorizontal.IsEnabled = estado;
            Objetos.cbTilesPrecargaAnchaOrientacionHorizontal.IsEnabled = estado;
            Objetos.cbTilesPrecargaGrandeOrientacionHorizontal.IsEnabled = estado;
            Objetos.cbTilesPrecargaPequeñaOrientacionVertical.IsEnabled = estado;
            Objetos.cbTilesPrecargaMedianaOrientacionVertical.IsEnabled = estado;
            Objetos.cbTilesPrecargaAnchaOrientacionVertical.IsEnabled = estado;
            Objetos.cbTilesPrecargaGrandeOrientacionVertical.IsEnabled = estado;

            Objetos.botonTilesCargarJuego.IsEnabled = estado;
        }
    }
}
