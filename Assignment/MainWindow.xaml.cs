using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Data.Models;

namespace Assignment;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private readonly TimGiaSuContext _context;

    public MainWindow()
    {
        InitializeComponent();
        _context = new TimGiaSuContext();
        LoadClassData();
        LoadTutorData();
    }

    private void LoadClassData()
    {
        var classes = _context.LopHocs
            .Select(lh => new
            {
                TenMonHoc = lh.TenMonHoc,
                GiaSu = lh.GiaSu.HoTen,
                TrangThai = lh.TrangThai
            })
            .ToList();

        ClassListView.ItemsSource = classes;
    }
    private void LoadTutorData()
    {
        var tutors = _context.GiaSus
            .Select(gs => new
            {
                TenGiaSu = gs.HoTen,
                KinhNghiem = gs.KinhNghiem + " năm",
                BangCap = gs.BangCap
            })
            .ToList();

        TutorListView.ItemsSource = tutors;
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
        LoginWindow loginWindow = new LoginWindow();
        loginWindow.ShowDialog(); 
    }

    private void Button_Click_1(object sender, RoutedEventArgs e)
    {
        RegisterWindow registerWindow = new RegisterWindow();
        registerWindow.ShowDialog();
    }
}
