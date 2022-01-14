//Класс МОДЕЛЬ
using System;
using System.Collections.Generic;
using System.Linq;
using ProjectBilling.DataAccess;

/*
Этот код создает модель для использования нашим представлением. 
Представление получает обновления из модели и через контроллер передает данные 
обратно в модель используя ссылку на IProjectsModel. Мы создали класс ProjectsModel 
реализующий IProjectsModel для возможности легкой расширяемости и тестируемости 
приложения. 

    */

namespace WPF_MFC
{
    public interface IProjectsModel
    {
        IEnumerable<Project> Projects { get; set; }
        //Событие для обновления вида об обвнолении данных
        event EventHandler<ProjectEventArgs> ProjectUpdated;

        //UpdateProject - метод представления проекта, который будет обновляться.
        void UpdateProject(Project project);
    }

    public class ProjectsModel : IProjectsModel
    {
        //Projects - свойство, содержащее коллекцию проектов, загружаемых из кода доступа к данным.
        public IEnumerable<Project> Projects { get; set; }

        //ProjectUpdated - это событие для уведомления экземпляра класса Project об обновлении.
        public event EventHandler<ProjectEventArgs>
            ProjectUpdated = delegate { };

        public ProjectsModel()
        {

            //При создании модели заполняем ее данными
            Projects = new DataServiceStub().GetProjects();
        }

        //Модель сообщает об обновлении данных
        private void RaiseProjectUpdated(Project project)
        {
            //Вызываем событие об обновлении данных
            ProjectUpdated(this,
                new ProjectEventArgs(project));
        }

        //UpdateProject - метод представления проекта, который будет обновляться.
        public void UpdateProject(Project project)
        {
            //находит необходимые данные с помощью методов расширения и лямбда-выражений
            //Project selectedProject= Projects.Where(p => p.ID == project.ID).FirstOrDefault() as Project;
            //Where - производит фильтрацию значений на основе заданного предиката
            Project selectedProject = Projects.Where(delegate(Project p)
            {
                return p.ID == project.ID;
            }).FirstOrDefault() as Project;//получаем один элемент
            selectedProject.Name = project.Name;
            selectedProject.Estimate = project.Estimate;
            selectedProject.Actual = project.Actual;
            //Уведомляем об обновлении данных
            RaiseProjectUpdated(selectedProject);
        }
    }

   //Создаем класс для уведомлении о событии
    public class ProjectEventArgs : EventArgs //класс содержащий данные о событии и представляющий значения для событий не содержащих данных
    {
        //Свойство с информацией об проекте к которому имеет место событие
        public Project Project { get; set; }

        //Конструктор
        public ProjectEventArgs(Project project)
        {
            Project = project;
        }
    }
}
