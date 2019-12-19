using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CRUD_CURSOS.Models;
using CRUD_CURSOS.Models.ViewModels;

namespace CRUD_CURSOS.Controllers
{
    public class TablaAlumnosController : Controller
    {
        // GET: TablaAlumnos
        public ActionResult Index()
        {
            List<TablaDeCursos> lst;
            using (UniversidadEntities db = new UniversidadEntities())
            {
                 lst = (from d in db.Cursos
                           select new TablaDeCursos
                           {
                               Nombre_Cursos = d.Nombre_Curso,
                               Materias = d.Materias,
                               Alumnos = d.Alumnos
                           }).ToList();
                    
            }
            return View(lst);
        }
        public ActionResult Nuevo() 
        {
            return View();
        }
        [HttpPost]
        public ActionResult Nuevo(AgregarCursos model) 
        {
            try 
            {
                if (ModelState.IsValid)
                {
                    using(UniversidadEntities db = new UniversidadEntities())
                    {
                        var Curso = new Cursos();
                        Curso.Nombre_Curso = model.Nombre_Cursos;
                        Curso.Materias = model.Materias;
                        Curso.Alumnos = model.Alumnos;

                        db.Cursos.Add(Curso);
                        db.SaveChanges();
                    }
                    return Redirect("/");
                }
                return View(model);
            }
            
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public ActionResult Editar()
        {
            TablaDeCursos model = new TablaDeCursos();
            using (UniversidadEntities db  = new UniversidadEntities())
            {
                var oTabla = db.Cursos.Find(model.Nombre_Cursos);
                model.Alumnos = oTabla.Alumnos;
                model.Materias = oTabla.Materias;
                model.Nombre_Cursos = oTabla.Nombre_Curso;
            }
                return View();
        }
        [HttpPost]
        public ActionResult Editar(AgregarCursos model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (UniversidadEntities db = new UniversidadEntities())
                    {
                        var Curso = new Cursos();
                        Curso.Nombre_Curso = model.Nombre_Cursos;
                        Curso.Materias = model.Materias;
                        Curso.Alumnos = model.Alumnos;

                        db.Entry(Curso).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                    }
                    return Redirect("/");
                }
                return View(model);
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
             [HttpGet]
        public ActionResult Eliminar(int Nombre_Cursos)
        {
            using (UniversidadEntities db = new UniversidadEntities())
            {

                var oTabla = db.Cursos.Find(Nombre_Cursos);
                db.Cursos.Remove(oTabla);
                db.SaveChanges();
            }
            return Redirect("~/TablaAlumnos/");
        }
    }
    }
  