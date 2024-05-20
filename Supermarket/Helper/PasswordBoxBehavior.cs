using Supermarket.ViewModels;

using System.Windows;
using System.Windows.Controls;
using Microsoft.Xaml.Behaviors;

namespace Supermarket.Helpers
{
    public class PasswordBoxBehavior : Behavior<PasswordBox>
    {
        protected override void OnAttached()
        {
            base.OnAttached();
            AssociatedObject.PasswordChanged += PasswordBox_PasswordChanged;
        }

        protected override void OnDetaching()
        {
            base.OnDetaching();
            AssociatedObject.PasswordChanged -= PasswordBox_PasswordChanged;
        }

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (AssociatedObject.DataContext is LoginVM viewModel)
            {
                viewModel.Password = AssociatedObject.Password;
            }
        }
    }
}