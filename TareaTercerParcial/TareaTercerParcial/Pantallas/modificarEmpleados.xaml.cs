using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TareaTercerParcial.Modelos;
using TareaTercerParcial.DataBase;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TareaTercerParcial.Pantallas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class modificarEmpleados : ContentPage
    {
        public modificarEmpleados(Empleados Ep)
        {
            InitializeComponent();
            BindingContext = Ep;
        }

        public Empleados Ep { get; }

        private async void btnModificar_Clicked(object sender, EventArgs e)
        {
            Empleados modEmple = new Empleados
            {
                Id_Empleado = Convert.ToInt32(txtId.Text),
                Nombre = txtNombre.Text,
                Apellido = txtApellido.Text,
                Edad = txtEdad.Text,
                Direccion = txtDireccion.Text,
                Puesto = txtPuestos.Text,
            };
            //await BaseDatos.CurrentDB.GuardarEmpleado(modEmple);
            if (await BaseDatos.CurrentDB.GuardarEmpleado(modEmple) != 0)
            {
                await DisplayAlert("Registro", "Datos Modificados de manera correcta", "Ok");
                await Navigation.PushAsync(new listaEmpleados());
            }
            else
            {
                await DisplayAlert("Registro", "Ha ocurrido un problema", "ok");
            }
        }

        private async void btnEliminar_Clicked(object sender, EventArgs e)
        {
            bool validacion = await DisplayAlert("Pregunta", "Esta seguro que desea eliminar este registro?", "Si", "No");
            if (validacion == true)
            {
                Empleados delEmple = new Empleados
                {
                    Id_Empleado = Convert.ToInt32(txtId.Text),
                    Nombre = txtNombre.Text,
                    Apellido = txtApellido.Text,
                    Edad = txtEdad.Text,
                    Direccion = txtDireccion.Text,
                    Puesto = txtPuestos.Text,
                };
                if (await BaseDatos.CurrentDB.EliminarEmpleado(delEmple) != 0)
                {
                    await DisplayAlert("Registro", "Datos Eliminados de manera correcta", "Ok");
                    await Navigation.PushAsync(new listaEmpleados());

                }
                else
                {
                    await DisplayAlert("Registro", "Ha ocurrido un problema", "Ok");
                }
            }
        }
    }
}