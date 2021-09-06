using Autodesk.Revit.UI;
using RevitAddin.ExternalEventExample.ExternalEvents;
using System;
using System.Windows;

namespace RevitAddin.ExternalEventExample.Views
{
    public partial class DeleteView : Window
    {
        public ExternalEvent deleteExternalEvent { get; set; } = DeleteExternalEventHandler.Create();

        public DeleteView()
        {
            InitializeComponent();
            InitializeSize();
            InitializeButtons();
        }

        private void InitializeButtons()
        {
            buttonDelete.Height = 24;
            buttonDelete.Width = 160;
            buttonDelete.Content = "Delete";
            buttonDelete.Click += (s, e) =>
            {
                deleteExternalEvent.Raise();
            };
        }

        private void InitializeSize()
        {
            this.Title = "ExternalEventExample";
            this.SizeToContent = SizeToContent.WidthAndHeight;
            this.Topmost = true;
            this.ShowInTaskbar = false;
            this.ResizeMode = ResizeMode.NoResize;
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }
    }
}