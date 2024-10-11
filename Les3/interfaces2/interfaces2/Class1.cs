namespace interfaces2
{
    // Een interface die er voor zorgt dat we tekst van een file kunnen inlezen en wegschrijven. Deze interface noem je IFile

    public interface IFile
    {
        void FileInlezen(string inputFile);        
        string FileInlezen2(string inputFile);
        void FileSchrijven(string outputFile);
        void FileSchrijven2(string outputFile, string textToWrite);

    }
    class Demo: IFile
    {
        public string  Tekst { get; set; }
        public void FileInlezen(string inputFile)
        {
            Tekst = new StreamReader(inputFile).ReadToEnd();
        }

        public string FileInlezen2(string inputFile)
        {
           return new StreamReader(inputFile).ReadToEnd();
        }

        public void FileSchrijven(string outputFile)
        {
            new StreamWriter(outputFile).Write(Tekst);
        }

        public void FileSchrijven2(string outputFile, string textToWrite)
        {
            new StreamWriter(outputFile).Write(textToWrite);
        }
    }

    //Een interface voor een notificatie in je smartphone. Elke notificatie bestaat uit een logo, titel en beschrijving. Je kan ook op een notificatie klikken. Noem deze interface INotification. 
    interface INotification
    {
        string LogoUrl { get; }
        string Title { get;}
        string Beschrijving { get; }

        void OnKlikEvent();
    }


    //Interface die ervoor zorgt we checkboxen/radiobuttons kunnen printen op het scherm. We verwachten hier een Select en Deselect functie. We willen ook weten of een item geselecteerd is of niet.
    interface ISelectable
    {
        void ShowOnScreen();
        void Select();
        void Deselect();

        bool IsSelected { get; }
    }

}
