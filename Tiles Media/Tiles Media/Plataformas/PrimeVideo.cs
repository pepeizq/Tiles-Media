using CommunityToolkit.WinUI.UI.Controls;
using Herramientas;
using Interfaz;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.VisualBasic;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.System;
using Windows.UI;
using static Tiles_Media.MainWindow;

namespace Plataformas
{
    public static class PrimeVideo
    {
        public static void Cargar()
        {
            Objetos.botonPrimeVideoBuscar.Click += BuscarClick;
            Objetos.botonPrimeVideoBuscar.PointerEntered += Animaciones.EntraRatonBoton2;
            Objetos.botonPrimeVideoBuscar.PointerExited += Animaciones.SaleRatonBoton2;

            Objetos.tbPrimeVideoBuscar.KeyDown += BuscarPulsar;

            Objetos.cbOpcionesPrimeVideoModo.SelectionChanged += CambiarModoEjecucion;
            Objetos.cbOpcionesPrimeVideoModo.PointerEntered += Animaciones.EntraRatonComboCaja2;
            Objetos.cbOpcionesPrimeVideoModo.PointerExited += Animaciones.SaleRatonComboCaja2;

            ApplicationDataContainer datos = ApplicationData.Current.LocalSettings;
     
            if (datos.Values["OpcionesPrimeVideoModo"] != null)
            {
                if ((int)datos.Values["OpcionesPrimeVideoModo"] == -1)
                {
                    Objetos.cbOpcionesPrimeVideoModo.SelectedIndex = 0;
                }
                else
                {
                    Objetos.cbOpcionesPrimeVideoModo.SelectedIndex = (int)datos.Values["OpcionesPrimeVideoModo"];
                }
            }
            else
            {
                Objetos.cbOpcionesPrimeVideoModo.SelectedIndex = 0;
            }
        }

        private static void CambiarModoEjecucion(object sender, SelectionChangedEventArgs e)
        {
            ApplicationDataContainer datos = ApplicationData.Current.LocalSettings;
            datos.Values["OpcionesPrimeVideoModo"] = Objetos.cbOpcionesPrimeVideoModo.SelectedIndex;
        }

        private static void BuscarClick(object sender, RoutedEventArgs e)
        {
            Buscar();
        }

        private static void BuscarPulsar(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key == VirtualKey.Enter)
            {
                Buscar();
            }
        }

        private static async void Buscar()
        {
            if (Objetos.tbPrimeVideoBuscar.Text.Trim().Length > 3)
            {
                ActivarDesactivar(false);
                Objetos.prPrimeVideoResultados.Visibility = Visibility.Visible;

                ApplicationDataContainer datos = ApplicationData.Current.LocalSettings;
                Objetos.gvPrimeVideoResultados.Items.Clear();

                await Task.Delay(100);

                string html = await Decompiladores.CogerHtml("https://www.primevideo.com/search/ref=atv_nb_sr?phrase=" + Objetos.tbPrimeVideoBuscar.Text.Trim());

                if (html != null) 
                {
                    int int1 = html.IndexOf("['search-default']");
                    string temp1 = html.Remove(0, int1);

                    int int2 = temp1.IndexOf("<script type=" + Strings.ChrW(34) + "text/template" + Strings.ChrW(34) + ">");
                    string temp2 = temp1.Remove(0, int2);

                    int int3 = temp2.IndexOf(">");
                    string temp3 = temp2.Remove(0, int3 + 1);

                    int int4 = temp3.IndexOf("</script>");
                    string temp4 = temp3.Remove(int4, temp3.Length - int4);

                    PrimeVideoAPI json = JsonConvert.DeserializeObject<PrimeVideoAPI>(temp4);

                    if (json != null) 
                    {
                        foreach (PrimeVideoAPIItem resultado in json.props.resultados.items)
                        {
                            PrimeVideoClase streaming = new PrimeVideoClase();
                            streaming.nombre = resultado.titulo.texto;

                            string imagen2 = resultado.packshot.imagen.src;

                            if (imagen2.Contains("._") == true)
                            {
                                int int6 = imagen2.IndexOf("._");
                                imagen2 = imagen2.Remove(int6, imagen2.Length - int6);
                                imagen2 = imagen2 + ".jpg";
                            }

                            streaming.imagenPequeña = imagen2;
                            streaming.imagenMedianayGrande = imagen2;

                            string id = resultado.packshot.enlace;
                            id = id.Replace("/detail/", null);

                            if (id.Contains("/ref=") == true)
                            {
                                int int5 = id.IndexOf("/ref=");
                                id = id.Remove(int5, id.Length - int5);
                            }

                            if ((int)datos.Values["OpcionesPrimeVideoModo"] == 0)
                            {
                                streaming.enlace = "https://www.primevideo.com/detail/" + id + "/";
                            }
                            else if ((int)datos.Values["OpcionesPrimeVideoModo"] == 1)
                            {
                                streaming.enlace = "primevideo://app/detail?asin=" + id;
                            }

                            ImageEx imagen = new ImageEx
                            {
                                IsCacheEnabled = true,
                                EnableLazyLoading = true,
                                Stretch = Stretch.UniformToFill,
                                Source = streaming.imagenMedianayGrande,
                                CornerRadius = new CornerRadius(2),
                                Tag = streaming
                            };

                            imagen.ImageExFailed += ImagenFalla;

                            Button2 botonItem = new Button2
                            {
                                Content = imagen,
                                Margin = new Thickness(0),
                                Padding = new Thickness(0),
                                BorderBrush = new SolidColorBrush((Color)Application.Current.Resources["ColorPrimario"]),
                                BorderThickness = new Thickness(2),
                                Tag = streaming,
                                MaxWidth = 350,
                                CornerRadius = new CornerRadius(5)
                            };

                            botonItem.Click += ImagenItemClick;
                            botonItem.PointerEntered += Animaciones.EntraRatonBoton2;
                            botonItem.PointerExited += Animaciones.SaleRatonBoton2;

                            TextBlock tbTt = new TextBlock
                            {
                                Text = streaming.nombre
                            };
              
                            ToolTipService.SetToolTip(botonItem, tbTt);
                            ToolTipService.SetPlacement(botonItem, PlacementMode.Bottom);

                            GridViewItem item = new GridViewItem
                            {
                                Content = botonItem,
                                Margin = new Thickness(5, 0, 5, 10)
                            };

                            Objetos.gvPrimeVideoResultados.Items.Add(item);
                        }
                    }
                }

                ActivarDesactivar(true);
                Objetos.prPrimeVideoResultados.Visibility = Visibility.Collapsed;
            }
        }

        private static void ImagenFalla(object sender, ImageExFailedEventArgs e)
        {
            ImageEx imagen = (ImageEx)sender;
            PrimeVideoClase streamingImagen = imagen.Tag as PrimeVideoClase;

            int i = 0;
            foreach (GridViewItem item in Objetos.gvPrimeVideoResultados.Items)
            {
                Button2 boton = item.Content as Button2;
                PrimeVideoClase streamingBoton = boton.Tag as PrimeVideoClase;

                if (streamingBoton.imagenMedianayGrande == streamingImagen.imagenMedianayGrande)
                {
                    break;
                }

                i += 1;
            }

            Objetos.gvPrimeVideoResultados.Items.RemoveAt(i);
        }

        private static void ImagenItemClick(object sender, RoutedEventArgs e)
        {
            Button boton = sender as Button;
            PrimeVideoClase streaming = boton.Tag as PrimeVideoClase;
            Random azar = new Random();

            Tiles.PrecargarMedia(streaming.nombre,
                    streaming.enlace, "amazon" + azar.Next(10000).ToString(),
                    streaming.imagenPequeña,
                    streaming.imagenMedianayGrande);
        }

        private static void ActivarDesactivar(bool estado)
        {
            Objetos.botonPrimeVideoBuscar.IsEnabled = estado;
            Objetos.tbPrimeVideoBuscar.IsEnabled = estado;
            Objetos.cbOpcionesPrimeVideoModo.IsEnabled = estado;
        }
    }

    public class PrimeVideoClase
    {
        public string nombre { get; set; }
        public string imagenPequeña { get; set; }
        public string imagenMedianayGrande { get; set; }
        public string enlace { get; set; }
    }
}
