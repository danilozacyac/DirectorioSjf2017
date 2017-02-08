﻿using System;
using System.IO;
using System.Linq;
using System.Windows;
using PadronApi.Dto;
using PadronApi.Model;
using Telerik.Windows.Controls;
using System.Configuration;

namespace DirectorioSjf2017
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnAceptar_Click(object sender, RoutedEventArgs e)
        {
            string path = ConfigurationManager.AppSettings["ErrorPath"].ToString();

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);

            }

            if (new AccesoModel().ObtenerUsuarioContraseña(TxtUsuario.Text, TxtPass.Password))
            {
                AccesoUsuario.Permisos = new PermisosModel().GetPermisosByUser(AccesoUsuario.Llave);

                Directorio padron = new Directorio();
                padron.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Usuario o contraseña incorrectos");
            }

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            StyleManager.ApplicationTheme = new Windows8Theme();
            TxtUsuario.Focus();
        }

        private void BtnSalir_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
