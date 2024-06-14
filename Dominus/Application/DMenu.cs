namespace Dominus.Application
{
    public class DMenu
    {
        public DMenu()
        {
            Options = new List<DMenu>();
        }

        public string Name { get; set; }

        public string Resource { get; set; }

        public string Icon { get; set; }

        public string Url { get; set; }

        public string Key { get; set; }

        public bool Visible { get; set; }

        public bool HasGroups
        {
            get
            {
                return Options.Count > 0;
            }
        }

        public List<DMenu> Options { get; set; }

        public Dictionary<Permission, bool> Permissions { get; set; }

        public override string ToString()
        {
            return Name;
        }

    }

    public enum Permission
    {
        Save,
        Update,
        Delete,
        Find,
        Approve,
        Cancel
    }
}
