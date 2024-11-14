namespace NotesTakingApp.Data
{
    public class NotesRepository
    {
        private AppDbContext _context;
        public NotesRepository(AppDbContext context)
        {
            _context = context;
        }

        public NotesRepository() : this(new AppDbContext())
        {

        }

        public void CreateNote(Note note)
        {
            _context.Notes.Add(note);
            _context.SaveChanges();
        }
        public List<Note> GetAllNotes()
        {
            return _context.Notes.ToList();
        }

        public Note? GetNoteById(int id)
        {
            return _context.Notes.Find(id);
        }

        public void DeleteNote(Note note)
        {
            _context.Remove(note);
            _context.SaveChanges();
        }

        public List<Note> FindNoteByText(string text)
        {
            return _context.Notes.Where(note => note.Content.Contains(text)).ToList();
        }
    }
}
