using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc;
using System.Data.SqlClient;
using System.Data;
using MVCPlantilla.Utilerias;
namespace Lab1.Controllers
{
    public class VideoController : Controller
    {
        //
        // GET: /Video/

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Agregar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Agregar(int idvideo, string titulo, int reproducciones, string url)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@idvideo", idvideo));
            parametros.Add(new SqlParameter("@titulo", titulo));
            parametros.Add(new SqlParameter("@reproducciones", reproducciones));
            parametros.Add(new SqlParameter("@url", url));
            BaseHelper.ejecutarSentencia("INSERT INTO video VALUES (@idvideo,@titulo,@reproducciones,@url)", CommandType.Text, parametros);
            return RedirectToAction("Index", "Home");
        }
        public ActionResult Modificar()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Modificar(int idvideo, string titulo, int reproducciones, string url)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@idvideo", idvideo));
            parametros.Add(new SqlParameter("@titulo", titulo));
            parametros.Add(new SqlParameter("@reproducciones", reproducciones));
            parametros.Add(new SqlParameter("@link", url));
            BaseHelper.ejecutarSentencia("UPDATE video set idvideo=@idvideo,titulo=@titulo,reproducciones=@reproducciones,url=@url where idvideo=@idvideo", CommandType.Text, parametros);
            return RedirectToAction("Index", "Home");
        }
        public ActionResult Eliminar()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Eliminar(int idvideo)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@idvideo", idvideo));
            BaseHelper.ejecutarSentencia("DELETE FROM video where idvideo=@idvideo", CommandType.Text, parametros);
            return RedirectToAction("Index", "Home");
        }

    }
}
