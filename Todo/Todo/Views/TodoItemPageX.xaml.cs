﻿using System;
using Todo.Repository;
using Xamarin.Forms;

namespace Todo
{
    public partial class TodoItemPageX : ContentPage
    {
        public TodoItemPageX()
        {
            InitializeComponent();

            NavigationPage.SetHasNavigationBar(this, true);
        }

        void saveClicked(object sender, EventArgs e)
        {
            var todoItem = (TodoItem)BindingContext;
            App.Repository.SaveItem(todoItem);
            this.Navigation.PopAsync();
        }

        void deleteClicked(object sender, EventArgs e)
        {
            var todoItem = (TodoItem)BindingContext;
            App.Repository.DeleteItem(todoItem.ID);
            this.Navigation.PopAsync();
        }

        void cancelClicked(object sender, EventArgs e)
        {
            var todoItem = (TodoItem)BindingContext;
            this.Navigation.PopAsync();
        }

        void speakClicked(object sender, EventArgs e)
        {
            var todoItem = (TodoItem)BindingContext;
            DependencyService.Get<ITextToSpeech>().Speak(todoItem.Name + " " + todoItem.Notes);
        }
    }
}
