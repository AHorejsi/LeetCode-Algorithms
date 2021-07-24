public sealed class File {
    public string Name { get; set; }
    public StringBuilder Content { get; private set; }
    
    public File(string name, string content) {
        this.Name = name;
        this.Content = new StringBuilder(content);
    }
    
    public String StringContent {
        get => this.Content.ToString();
        set {
            this.Content.Clear();
            this.Content.Append(value);
        }
    }
}

public sealed class Folder {
    public string Name { get; set; }
    internal IDictionary<string, File> files;
    public Folder Parent { get; private set; }
    internal IDictionary<string, Folder> subfolders;
    
    public Folder(string name, Folder parent) {
        this.Name = name;
        this.files = new SortedDictionary<string, File>();
        this.Parent = parent;
        this.subfolders = new SortedDictionary<string, Folder>();
    }
    
    public IList<string> Ls(string path) {
        string[] directories = path.Split('/', StringSplitOptions.RemoveEmptyEntries);
        Folder currentFolder = this;
        
        foreach (string directoryName in directories) {
            Folder subfolder;
            if (currentFolder.subfolders.TryGetValue(directoryName, out subfolder)) {
                currentFolder = subfolder;
            }
            else {
                File file;
                if (currentFolder.files.TryGetValue(directoryName, out file)) {
                    return new List<string> { file.Name };
                }
                else {
                    throw new ArgumentException("Directory does not exist");
                }
            }
        }
        
        return this.MergeFileAndFolderNames(currentFolder.files.Keys, currentFolder.subfolders.Keys);
    }
    
    private IList<string> MergeFileAndFolderNames(IEnumerable<string> fileNames, IEnumerable<string> folderNames) {
        IList<string> names = new List<string>();
        
        IEnumerator<string> left = fileNames.GetEnumerator();
        IEnumerator<string> right = folderNames.GetEnumerator();
        
        bool moreOnLeft = left.MoveNext();
        bool moreOnRight = right.MoveNext();
        
        while (moreOnLeft && moreOnRight) {
            if (left.Current.CompareTo(right.Current) <= 0) {
                names.Add(left.Current);
                moreOnLeft = left.MoveNext();
            }
            else {
                names.Add(right.Current);
                moreOnRight = right.MoveNext();
            }
        }
        
        while (moreOnLeft) {
            names.Add(left.Current);
            moreOnLeft = left.MoveNext();
        }
        
        while (moreOnRight) {
            names.Add(right.Current);
            moreOnRight = right.MoveNext();
        }
        
        return names;
    }
    
    public void Mkdir(string path) {
        string[] directories = path.Split('/', StringSplitOptions.RemoveEmptyEntries);
        Folder currentFolder = this;
        
        foreach (string directoryName in directories) {
            Folder subfolder;
            if (!currentFolder.subfolders.TryGetValue(directoryName, out subfolder)) {
                subfolder = new Folder(directoryName, currentFolder);
                currentFolder.subfolders.Add(directoryName, subfolder);
            }
            
            currentFolder = subfolder;
        }
    }
    
    public void AddContentToFile(string filePath, string content) {
        string[] directories = filePath.Split('/', StringSplitOptions.RemoveEmptyEntries);
        Folder currentFolder = this;
        
        foreach (string directoryName in directories.SkipLast(1)) {
            currentFolder = currentFolder.subfolders[directoryName];
        }
        
        string fileName = directories.Last();
        
        File file;
        if (currentFolder.files.TryGetValue(fileName, out file)) {
            file.Content.Append(content);
        }
        else {
            file = new File(fileName, content);
            currentFolder.files.Add(fileName, file);
        }
    }
    
    public string ReadContentFromFile(string filePath) {
        string[] directories = filePath.Split('/', StringSplitOptions.RemoveEmptyEntries);
        Folder currentFolder = this;
        
        foreach (string directoryName in directories.SkipLast(1)) {
            currentFolder = currentFolder.subfolders[directoryName];
        }
        
        string fileName = directories.Last();
        return currentFolder.files[fileName].StringContent;
    }
}

public sealed class FileSystem {
    public Folder Root { get; }

    public FileSystem() {
        this.Root = new Folder("", null);
    }
    
    public IList<string> Ls(string path) => this.Root.Ls(path);
    
    public void Mkdir(string path) => this.Root.Mkdir(path);
    
    public void AddContentToFile(string filePath, string content) => this.Root.AddContentToFile(filePath, content);
    
    public string ReadContentFromFile(string filePath) => this.Root.ReadContentFromFile(filePath);
}

/**
 * Your FileSystem object will be instantiated and called as such:
 * FileSystem obj = new FileSystem();
 * IList<string> param_1 = obj.Ls(path);
 * obj.Mkdir(path);
 * obj.AddContentToFile(filePath,content);
 * string param_4 = obj.ReadContentFromFile(filePath);
 */