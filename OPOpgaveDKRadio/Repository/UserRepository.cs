using OPOpgaveDKRadio.Model;

namespace OPOpgaveDKRadio.Repository;

public class UserRepository
{
	private readonly List<User> _users = new List<User>
	{
		new User { Username = "admin", Password = "admin123", Role = "Admin" },
		new User { Username = "user", Password = "user123", Role = "User" }
	};

	public User? Login(string username, string password)
	{
		return _users.FirstOrDefault(u => u.Username == username && u.Password == password);
	}
}