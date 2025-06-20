using Microsoft.Win32;
using System;
using System.IO;
using System.Windows;
using System.Windows.Input;
using System.Windows.Forms;
using MessageBox = System.Windows.MessageBox;
using OpenFileDialog = Microsoft.Win32.OpenFileDialog;
using SaveFileDialog = Microsoft.Win32.SaveFileDialog;

namespace WpfTextEditor
{
    public partial class MainWindow : Window
    {
        private const string RegistryBasePath = @"SOFTWARE\ISPP\TextEditor";
        private const string ProgramPath = @"C:\Program Files\TextEditor";

        public MainWindow()
        {
            InitializeComponent();
            InitializeRegistry();
        }

        private void InitializeRegistry()
        {
            try
            {
                // Создание разделов и ключей
                using (RegistryKey baseKey = Registry.LocalMachine.CreateSubKey(@"SOFTWARE\ISPP\TextEditor"))
                {
                    baseKey.SetValue("Path", ProgramPath);
                    if (baseKey.GetValue("DefaultFolder") == null)
                        baseKey.SetValue("DefaultFolder", Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments));
                }

                using (RegistryKey infoKey = Registry.LocalMachine.CreateSubKey(@"SOFTWARE\ISPP\TextEditor\Info"))
                {
                    infoKey.SetValue("ApplicationDescription", "Простой WPF-текстовый редактор");
                    infoKey.SetValue("Version", "1.0.0");
                }
            }
            catch (UnauthorizedAccessException)
            {
                MessageBox.Show("Ошибка: Запустите программу от имени администратора для записи в реестр.", "Ошибка доступа", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private string GetDefaultFolder()
        {
            try
            {
                using (RegistryKey key = Registry.LocalMachine.OpenSubKey(RegistryBasePath))
                {
                    return key?.GetValue("DefaultFolder")?.ToString() ?? Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                }
            }
            catch
            {
                return Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            }
        }

        private void OpenFile_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                InitialDirectory = GetDefaultFolder(),
                Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*"
            };

            if (openFileDialog.ShowDialog() == true)
                TextEditorBox.Text = File.ReadAllText(openFileDialog.FileName);
        }

        private void SaveFile_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                InitialDirectory = GetDefaultFolder(),
                Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*"
            };

            if (saveFileDialog.ShowDialog() == true)
                File.WriteAllText(saveFileDialog.FileName, TextEditorBox.Text);
        }

        private void SetDefaultFolder_Click(object sender, RoutedEventArgs e)
        {
            using (var folderDialog = new FolderBrowserDialog())
            {
                folderDialog.Description = "Выберите папку по умолчанию для файлов";
                if (folderDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    try
                    {
                        using (RegistryKey key = Registry.LocalMachine.OpenSubKey(RegistryBasePath, writable: true))
                        {
                            key?.SetValue("DefaultFolder", folderDialog.SelectedPath);
                            MessageBox.Show("Папка по умолчанию обновлена в реестре.");
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Не удалось сохранить путь. Запустите программу от имени администратора.");
                    }
                }
            }
        }

        private void Exit_Click(object sender, RoutedEventArgs e) => this.Close();

        // Обработка горячих клавиш
        private void Window_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (Keyboard.Modifiers == ModifierKeys.Control)
            {
                if (e.Key == Key.S)
                {
                    SaveFile_Click(sender, e);
                    e.Handled = true;
                }
                else if (e.Key == Key.O)
                {
                    OpenFile_Click(sender, e);
                    e.Handled = true;
                }
            }
        }
    }
}
