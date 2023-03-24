using Microsoft.UI;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media;
using static Tiles_Media.MainWindow;

namespace Interfaz
{
    public static class ScrollViewers
    {
        public static void Cargar()
        {
            Objetos.nvItemSubirArriba.PointerPressed += SubirArriba;
            Objetos.nvItemSubirArriba.PointerEntered += Animaciones.EntraRatonNvItem2;
            Objetos.nvItemSubirArriba.PointerExited += Animaciones.SaleRatonNvItem2;

            Objetos.svPresentacion.ViewChanging += MoverScroll;
            Objetos.svNetflixResultados.ViewChanging += MoverScroll;
            Objetos.svDisneyPlusResultados.ViewChanging += MoverScroll;
            Objetos.svPrimeVideoResultados.ViewChanging += MoverScroll;
            Objetos.svSpotifyResultados.ViewChanging += MoverScroll;
            Objetos.svTilesPrecarga.ViewChanging += MoverScroll;
            Objetos.svOpciones.ViewChanging += MoverScroll;
        }

        private static void MoverScroll(object sender, ScrollViewerViewChangingEventArgs args)
        {
            ScrollViewer sv = sender as ScrollViewer;

            if (sv.VerticalOffset > 150)
            {
                Objetos.nvItemSubirArriba.Visibility = Visibility.Visible;
            }
            else
            {
                Objetos.nvItemSubirArriba.Visibility = Visibility.Collapsed;
            }
        }

        public static void SubirArriba(object sender, RoutedEventArgs e)
        {
            NavigationViewItem nvItem = sender as NavigationViewItem;
            nvItem.Visibility = Visibility.Collapsed;

            Grid grid = nvItem.Content as Grid;
            grid.Background = new SolidColorBrush(Colors.Transparent);

            if (Objetos.gridNetflix.Visibility == Visibility.Visible)
            {
                Objetos.svNetflixResultados.ChangeView(null, 0, null);
            }
            else if (Objetos.gridDisneyPlus.Visibility == Visibility.Visible)
            {
                Objetos.svDisneyPlusResultados.ChangeView(null, 0, null);
            }
            else if (Objetos.gridPrimeVideo.Visibility == Visibility.Visible)
            {
                Objetos.svPrimeVideoResultados.ChangeView(null, 0, null);
            }
            else if (Objetos.gridSpotify.Visibility == Visibility.Visible)
            {
                Objetos.svSpotifyResultados.ChangeView(null, 0, null);
            }
            else if (Objetos.gridTilesPrecarga.Visibility == Visibility.Visible)
            {
                Objetos.svTilesPrecarga.ChangeView(null, 0, null);
            }
            else if (Objetos.gridOpciones.Visibility == Visibility.Visible)
            {
                Objetos.svOpciones.ChangeView(null, 0, null);
            }
        }

        public static void EnseñarSubir(ScrollViewer sv)
        {
            if (sv.VerticalOffset > 50)
            {
                Objetos.nvItemSubirArriba.Visibility = Visibility.Visible;
            }
            else
            {
                Objetos.nvItemSubirArriba.Visibility = Visibility.Collapsed;
            }
        }
    }
}
