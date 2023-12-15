using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Ports;

namespace Temperatura
{
  class Program
  {
    static void Main(string[] args)
    {
      DateTime Lunes = DateTime.Today;
      String connStr = "User ID=INFOMOVIL;Password=INFO";
      string mensaje = "";
      SerialPort puerto;

      String filePath = AppDomain.CurrentDomain.BaseDirectory + "//Log" + DateTime.Today.ToString("yyyy-MM-dd") + ".log";
      TextWriter writer = File.CreateText(filePath);

      //Busca localización de los archivos
      FachadaINFOMOVIL.Servicios servInfo = new FachadaINFOMOVIL.Servicios();

      puerto = new SerialPort
      {
        PortName = "COM3",
        BaudRate = 9600,
        ReadTimeout = 5000
      };

      try
      {
        if (!puerto.IsOpen) puerto.Open();
        String cadena = puerto.ReadLine();
        puerto.Close();
        FachadaINFOMOVIL.Medicion Medicion = new FachadaINFOMOVIL.Medicion();
        Medicion.FECHA = DateTime.Now;
        Medicion.LECTURA = double.Parse(cadena);
        servInfo.GrabaMedicion(Medicion, connStr, ref mensaje);
        if (mensaje != "") throw new Exception(mensaje);
        log(writer, "LECTURA(" + DateTime.Now.ToShortTimeString() + ") " + cadena);
      }
      catch (Exception ex)
      {
        FachadaINFOMOVIL.Medicion Medicion = new FachadaINFOMOVIL.Medicion();
        Medicion.FECHA = DateTime.Now;
        Medicion.DESCRIPCION = "Error :" + ex.Message;
        servInfo.GrabaMedicion(Medicion, connStr, ref mensaje);
        if (puerto.IsOpen) puerto.Close();
        log(writer, ex.Message);
      }

      writer.Close();
    }
    static void log(TextWriter writer, String text)
    {
      Console.OutputEncoding = System.Text.Encoding.UTF8;
      writer.WriteLine(text);
      Console.WriteLine(text);
    }
  }
}
