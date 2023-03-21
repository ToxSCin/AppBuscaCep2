﻿using AppBuscaCep2.Model;
using AppBuscaCep2.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppBuscaCep2.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class BairrosPorCidade : ContentPage
    {
        ObservableCollection<Cidade> lista_cidades = new ObservableCollection<Cidade>();
        ObservableCollection<Bairro> lista_bairros = new ObservableCollection<Bairro>();
        public BairrosPorCidade ()
		{
			InitializeComponent ();
		}

        private async void pck_estado_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Picker disparador = sender as Picker;
                string estado_selecionado = disparador.SelectedItem as string;
                List<Cidade> arr_cidades = await DataService.GetCidadeByEstado(estado_selecionado);
                lista_cidades.Clear();
            }
            catch (Exception ex)
            {
                await DisplayAlert("Erro Ai Man", ex.Message, "Alr");
            }
        }

        private async void pck_cidade_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Picker disparador = sender as Picker;
                Cidade cidade_selecionada = disparador.SelectedItem as Cidade;
                List<Bairro> arr_bairros = await DataService.GetBairrosByIdCidade(cidade_selecionada.id_cidade);
                lista_bairros.Clear();
                arr_bairros.ForEach(i => lista_bairros.Add(i));
            }
            catch (Exception ex)
            {
                await DisplayAlert("Erro Ai Man", ex.Message, "Alr");
            }

        }
    }
}