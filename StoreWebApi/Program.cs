<Window x:Class="WpfTextEditor.MainWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        Title="TextEditor" Height="450" Width="800"
        KeyDown="Window_KeyDown">
    <DockPanel>
        <Menu DockPanel.Dock="Top">
            <MenuItem Header="_File">
                <MenuItem Header="Open" Click="OpenFile_Click" InputGestureText="Ctrl+O"/>
                <MenuItem Header="Save" Click="SaveFile_Click" InputGestureText="Ctrl+S"/>
                <Separator/>
                <MenuItem Header="Set Default Folder" Click="SetDefaultFolder_Click"/>
                <Separator/>
                <MenuItem Header="Exit" Click="Exit_Click"/>
            </MenuItem>
        </Menu>
        <TextBox Name="TextEditorBox" AcceptsReturn="True" AcceptsTab="True"
                 VerticalScrollBarVisibility="Auto" HorizontalScrollBarVisibility="Auto"
                 FontSize="14" TextWrapping="Wrap"/>
    </DockPanel>
</Window>
