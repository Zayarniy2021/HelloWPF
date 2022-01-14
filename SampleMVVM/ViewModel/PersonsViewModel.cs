using System;
using System.Collections.Generic;
using System.ComponentModel;//Подключить!
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;//Подключить!
using System.Windows.Data;
using SampleMVVM.Data;//Подключаем наши данные

namespace SampleMVVM.ViewModel
{
    //Используем DepencyModel
    //две части
    //статическая
    //динамическая
    class PersonsViewModel: DependencyObject
    {

        //propd - tab 2 раза

        //свойства зависимости

        //динамическая часть
        public string FilterText
        {
            //возвращаем с генерацией? сообщения о том, что мы вернули значение
            get { return (string)GetValue(FilterTextProperty); }
            //устанавливаем с генерацией сообщения о том, что мы установили значение
            set { SetValue(FilterTextProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        //статическая часть
        public static readonly DependencyProperty FilterTextProperty =
            DependencyProperty.Register("FilterText", typeof(string), typeof(PersonsViewModel), new PropertyMetadata("", FilterText_Changed));

        public static void FilterText_Changed(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var current = d as PersonsViewModel;
            if (current != null)
            {
                current.Items.Filter = null;
                //связываем фильтр методом фильтрации
                //Filter задаем метод обратного вызова, который будет определять подходит ли
                //элемент фильтру или нет
                current.Items.Filter = current.FilterPerson;
            }
        }



        //Свойство для отображения и фильтрации коллекции(данных)
        public ICollectionView Items
        {
            get { return (ICollectionView)GetValue(ItemsProperty); }
            set { SetValue(ItemsProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Items.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ItemsProperty =
            DependencyProperty.Register("Items", typeof(ICollectionView), typeof(PersonsViewModel), new PropertyMetadata(null));

        //возвращаем экземляр нашей коллекции
        public PersonsViewModel()
        {
            Items = CollectionViewSource.GetDefaultView(Person.GetPersons());
            Items.Filter = FilterPerson;
        }

        //бизнес логика
        //Просматривает все элементы
        bool FilterPerson(object obj)
        {
            bool result = true;
            Person current = obj as Person;
            if (!string.IsNullOrWhiteSpace(FilterText)//В фильтре не пустая строка
                && current != null //
                && !current.FirstName.Contains(FilterText) 
                && !current.LastName.Contains(FilterText))
                result = false;
            return result;
        }
    }
}
