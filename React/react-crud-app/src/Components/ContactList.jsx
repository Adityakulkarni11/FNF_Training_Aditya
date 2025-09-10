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
          setContacts(contacts.filter((c) => c.id !== id));
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
      <div className="row">
        {contacts.map((contact) => (
          <div className="col-md-4 mb-4" key={contact.id}>
            <div className="card shadow">
              
            <img
            src={`/images/${contact.photo.split('/').pop()}`}
            alt={contact.name}
            className="card-img-top"
            style={{ height: "250px", objectFit: "cover" }}
            />

              <div className="card-body">
                <h5 className="card-title">{contact.name}</h5>
                <p className="card-text">
                  <strong>Phone:</strong> {contact.phoneNo}
                </p>
                <div className="d-flex justify-content-between">
                  <Link
                    to={`/contacts/view/${contact.id}`}
                    className="btn btn-sm btn-primary"
                  >
                    View
                  </Link>
                  <Link
                    to={`/contacts/update/${contact.id}`}
                    className="btn btn-sm btn-warning"
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
              </div>
            </div>
          </div>
        ))}
      </div>
    </div>
  );
}

export default ContactList;
