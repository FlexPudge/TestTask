using TestWebApplication.Data.Model;

namespace TestApp.Data.Service
{
    class ContextDB
    {
        private static TestDBContext _context;

        public static TestDBContext GetContext()
        {
            if (_context == null)
                _context = new TestDBContext();
            return _context;
        }
    }
}
