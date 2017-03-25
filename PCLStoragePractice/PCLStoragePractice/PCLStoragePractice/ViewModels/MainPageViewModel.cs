using PCLStorage;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PCLStoragePractice.ViewModels
{
    public class MainPageViewModel : BindableBase, INavigationAware
    {

        #region Username
        private string _username;
        /// <summary>
        /// Username
        /// </summary>
        public string Username
        {
            get { return this._username; }
            set { this.SetProperty(ref this._username, value); }
        }
        #endregion


        #region Password
        private string _password;
        /// <summary>
        /// Password
        /// </summary>
        public string Password
        {
            get { return this._password; }
            set { this.SetProperty(ref this._password, value); }
        }
        #endregion

        public DelegateCommand SaveCommand => new DelegateCommand(async () =>
        {
            // get hold of the file system
            IFolder rootFolder = FileSystem.Current.LocalStorage;

            // create a folder, if one does not exist already
            IFolder folder = await rootFolder.CreateFolderAsync("Folder", CreationCollisionOption.OpenIfExists);

            // create a file, overwriting any existing file
            IFile file = await folder.CreateFileAsync("Account.txt", CreationCollisionOption.ReplaceExisting);

            // populate the file with some text
            await file.WriteAllTextAsync(String.Format("{0},{1}", Username, Password));
        });

        public MainPageViewModel()
        {
            loadSavedLoginData();
        }

        private async void loadSavedLoginData()
        {
            // get hold of the file system
            IFolder rootFolder = FileSystem.Current.LocalStorage;
            // create a folder, if one does not exist already
            IFolder folder = await rootFolder.CreateFolderAsync("Folder", CreationCollisionOption.OpenIfExists);
            // create a file, overwriting any existing file
            IFile file = await folder.CreateFileAsync("Account.txt", CreationCollisionOption.OpenIfExists);
            var text = await file.ReadAllTextAsync();

            var splitData = text.Split(new string[] { "," }, StringSplitOptions.None);
            if (splitData.Length == 2)
            {
                Username = splitData[0];
                Password = splitData[1];
            }
        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {

        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {

        }
    }
}
