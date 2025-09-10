import { useEffect, useState } from "react";
import { useNavigate, useParams } from "react-router-dom";
import { ContactService } from "../Service/ContactService";

function EditContact() {
  const { id } = useParams();
  const navigate = useNavigate();
  const [contact, setContact] = useState({
    id: "",
    name: "",
    phoneNo: "",
    photo: ""
  });
  const [error, setError] = useState("");

  useEffect(() => {
    ContactService.getContactById(id)
      .then((response) => {
        setContact(response.data);
      })
      .catch((err) => {
        setError("Failed to load contact.");
        console.error(err);
      });
  }, [id]);

  const handleChange = (e) => {
    setContact({ ...contact, [e.target.name]: e.target.value });
  };

  const handleSubmit = (e) => {
    e.preventDefault();
    ContactService.updateContact(contact)
      .then(() => {
        alert("Contact updated successfully!");
        navigate("/contacts/all");
      })
      .catch((err) => {
        setError("Failed to update contact.");
        console.error(err);
      });
  };

  return (
    <div className="container mt-4">
      <h2 className="mb-4">Edit Contact</h2>
      {error && <div className="alert alert-danger">{error}</div>}
      <form onSubmit={handleSubmit} className="card p-4 shadow">
        <div className="mb-3">
          <label className="form-label">Name</label>
          <input
            name="name"
            value={contact.name}
            onChange={handleChange}
            className="form-control"
            required
          />
        </div>
        <div className="mb-3">
          <label className="form-label">Phone Number</label>
          <input
            name="phoneNo"
            value={contact.phoneNo}
            onChange={handleChange}
            className="form-control"
            required
          />
        </div>
        <div className="mb-3">
          <label className="form-label">Photo URL</label>
          <input
            name="photo"
            value={contact.photo}
            onChange={handleChange}
            className="form-control"
          />
        </div>
        {contact.photo && (
          <div className="mb-3 text-center">
            <img
              src={contact.photo}
              alt="Contact"
              style={{ height: "200px", objectFit: "cover" }}
              className="img-thumbnail"
            />
          </div>
        )}
        <button type="submit" className="btn btn-primary">
          Update Contact
        </button>
      </form>
    </div>
  );
}

export default EditContact;
