using Abp.Application.Navigation;
using Abp.Localization;

namespace AnimalRegister.Web
{
    public class AnimalRegisterNavigationProvider : NavigationProvider
    {
        // <summary>
        /// Generates the navigation
        /// </summary>
        public override void SetNavigation(INavigationProviderContext context)
        {
            var mainMenu = GetMenu(context, "MainMenu");
            CreateEntriesMenu(mainMenu);
            CreateTrashMenu(mainMenu);
        }

        /// <summary>
        /// Creates the entries menu
        /// </summary>
        private void CreateEntriesMenu(MenuDefinition menu)
        {
            menu.AddItem(CreateMenuItem(
                "entries",
                L("Navigation_Entries"),
                "#/entries",
                "fa-list",
                templateUrl: "/app/main/views/entries/index.cshtml",
                routeUrl: "/entries"
            ));

            menu.AddItem(CreateMenuItem(
                "entries_create",
                L("entries_create"),
                "#/entries/create",
                null,
                templateUrl: "/app/main/views/entries/create.cshtml",
                routeUrl: "/entries/create",
                hidden: true
            ));

            menu.AddItem(CreateMenuItem(
                "entries_edit",
                L("entries_edit"),
                "#/entries/edit/",
                null,
                templateUrl: "/app/main/views/entries/edit.cshtml",
                routeUrl: "/entries/:entryid/edit",
                hidden: true
            ));
        }

        /// <summary>
        /// Creates the trash menu
        /// </summary>
        private void CreateTrashMenu(MenuDefinition menu)
        {
            menu.AddItem(CreateMenuItem(
                "trash",
                L("Navigation_Trash"),
                "#/trash",
                "fa-trash",
                templateUrl: "/app/main/views/trash/index.cshtml",
                routeUrl: "/trash"
            ));
        }

        /// <summary>
        /// Retrieves a menu by its label
        /// </summary>
        private MenuDefinition GetMenu(INavigationProviderContext context, string label)
        {
            return context.Manager.Menus[label];
        }

        /// <summary>
        /// Creates a new menu entry
        /// </summary>
        private MenuItemDefinition CreateMenuItem(
            string name,
            ILocalizableString displayName,
            string url = null,
            string icon = null,
            string requiredPermissions = null,
            string templateUrl = null,
            string routeUrl = null,
            bool hidden = false)
        {
            var data = new
            {
                templateUrl = templateUrl,
                hidden = hidden,
                routeUrl = routeUrl
            };

            return new MenuItemDefinition(
                name,
                displayName,
                url: (!string.IsNullOrWhiteSpace(url) ? url : null),
                icon: (!string.IsNullOrWhiteSpace(icon) ? icon : null),
                requiredPermissionName: (!string.IsNullOrWhiteSpace(requiredPermissions) ? requiredPermissions : null),
                customData: data
            );
        }

        /// <summary>
        /// Localization helper
        /// </summary>
        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, AnimalRegisterConstants.LocalizationSourceName);
        }
    }
}