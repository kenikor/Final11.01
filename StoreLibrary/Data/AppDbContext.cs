<Window x:Class="WpfTextEditor.MainWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        Title="WPF Text Editor" Height="450" Width="800"
        KeyDown="Window_KeyDown">
    <Grid Margin="10">
        <Grid.RowDefinitions>
            <RowDefinition Height="Auto"/>
            <RowDefinition Height="*"/>
        </Grid.RowDefinitions>

        <StackPanel Orientation="Horizontal" Margin="0,0,0,10">
            <Button x:Name="btnOpen" Content="Открыть" Width="80" Margin="5" Click="btnOpen_Click"/>
            <Button x:Name="btnSave" Content="Сохранить" Width="80" Margin="5" Click="btnSave_Click"/>
            <Button x:Name="btnFolder" Content="Выбрать папку по умолчанию" Width="200" Margin="5" Click="btnFolder_Click"/>
        </StackPanel>

        <TextBox x:Name="txtEditor" Grid.Row="1" AcceptsReturn="True" AcceptsTab="True" VerticalScrollBarVisibility="Auto" HorizontalScrollBarVisibility="Auto"/>
    </Grid>
</Window>
