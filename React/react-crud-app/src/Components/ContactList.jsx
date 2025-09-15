import { useEffect, useState } from "react";
import { ContactService } from "../Service/ContactService";
import { Link } from "react-router-dom";

function ContactList() {
  const [contacts, setContacts] = useState([]);
  const [error, setError] = useState("");

  useEffect(() => {
    ContactService.getAllContacts()
      .then((res) => setContacts(res.data))
      .catch((err) => {
        setError("Failed to fetch contacts");
        console.error(err);
      });
  }, []);

  const handleDelete = (id) => {
  if (window.confirm("Are you sure you want to delete this contact?")) {
    ContactService.deleteContact(id)
      .then(() => {
        // Re-fetch contacts from the backend
        ContactService.getAllContacts()
          .then((res) => setContacts(res.data))
          .catch((err) => {
            setError("Failed to refresh contacts after deletion");
            console.error(err);
          });
      })
      .catch((err) => {
        alert("Failed to delete contact.");
        console.error(err);
      });
  }
};


  return (
    <div className="container mt-4">
      <h2 className="mb-4 text-center">All Contacts</h2>
      {error && <div className="alert alert-danger">{error}</div>}
      <table className="table table-bordered table-hover">
        <thead className="table-dark">
          <tr>
            <th>Photo</th>
            <th>Name</th>
            <th>Phone No</th>
            <th>Actions</th>
          </tr>
        </thead>
        <tbody>
          {contacts.map((contact) => (
            <tr key={contact.id}>
              <td>
                <img
                  src={`/images/${contact.photo.split('/').pop()}`}
                  alt={contact.name}
                  style={{ width: "80px", height: "80px", objectFit: "cover" }}
                />
              </td>
              <td>{contact.name}</td>
              <td>{contact.phoneNo}</td>
              <td>
                <div className="btn-group" role="group">
                  <Link
                    to={`/contacts/view/${contact.id}`}
                    className="btn btn-sm btn-primary"
                  >
                    View
                  </Link>
                  <Link
                    to={`/contacts/update/${contact.id}`}
                    className="btn btn-sm btn-warning mx-2"
                  >
                    Update
                  </Link>
                  <button
                    className="btn btn-sm btn-danger"
                    onClick={() => handleDelete(contact.id)}
                  >
                    Delete
                  </button>
                </div>
              </td>
            </tr>
          ))}
        </tbody>
      </table>
    </div>
  );
}

export default ContactList;
