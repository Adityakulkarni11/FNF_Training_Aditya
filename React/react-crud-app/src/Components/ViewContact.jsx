import { useEffect, useState } from "react";
import { useParams } from "react-router-dom";
import { ContactService } from "../Service/ContactService";

function ViewContact() {
  const { id } = useParams();
  const [contact, setContact] = useState(null);
  const [error, setError] = useState("");

  useEffect(() => {
    ContactService.getContactById(id)
      .then((res) => setContact(res.data))
      .catch((err) => {
        setError("Failed to load contact.");
        console.error(err);
      });
  }, [id]);

  if (error) return <div className="alert alert-danger">{error}</div>;
  if (!contact) return <div className="text-center mt-4">Loading...</div>;

  return (
    <div className="container mt-4">
      <h2 className="mb-4">Contact Details</h2>
      <div className="card shadow p-4">
        <div className="row">
          <div className="col-md-4">
            
            <img
            src={`/images/${contact.photo.split('/').pop()}`}
            alt={contact.name}
            className="card-img-top"
            style={{ height: "250px", objectFit: "cover" }}
            />

          </div>
          <div className="col-md-8">
            <h3>{contact.name}</h3>
            <p><strong>Phone:</strong> {contact.phoneNo}</p>
            <p><strong>ID:</strong> {contact.id}</p>
          </div>
        </div>
      </div>
    </div>
  );
}

export default ViewContact;
