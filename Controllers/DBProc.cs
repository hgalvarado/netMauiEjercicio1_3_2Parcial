using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using netMauiEjercicio1_3.Models;
using System.Threading.Tasks;


namespace netMauiEjercicio1_3.Controllers
{
    public class DBProc
    {

        readonly SQLiteAsyncConnection _connection;

        public DBProc() { }
        public DBProc(string path)
        {
            _connection = new SQLiteAsyncConnection(path);
            //**Todos los objetos de bases de datos**

            //Crea una tabla tomando en cuenta los parametros de la clase Personas
            _connection.CreateTableAsync<ClassPerson>().Wait();
            //_connection.CreateTableAsync<ClassPerson>().Wait();
        }
        /*CRUD de la BDPROC*/
        //CREATE, READ, UPDATE, DELETE

        public Task<int> addPersons(ClassPerson person)
        {
            if (person.idClass == 0)
            {
                return _connection.InsertAsync(person);
            }
            else
            {
                return _connection.UpdateAsync(person);
            }
        }
        public Task<List<ClassPerson>> listPersons()
        {
            return _connection.Table<ClassPerson>().ToListAsync();
        }

        public Task<ClassPerson> GetPersonID(int id)
        {
            return _connection.Table<ClassPerson>()
                .Where(p => p.idClass == id)
                .FirstOrDefaultAsync();
        }

        public Task<int> DeletePersons(ClassPerson personas)
        {
            return _connection.DeleteAsync(personas);
        }
        
    }
}
