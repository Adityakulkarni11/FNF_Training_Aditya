import React, { useState, useEffect, createContext, useContext } from 'react';

export const ContactContext = createContext();

const baseUrl = "http://localhost:5182/contacts";

// Component to fetch and display contacts
function ContactDB() {
    const [contactsData, setContactsData] = useContext(ContactContext);

    const handleFetch = () => {
        fetch(baseUrl)
            .then(res => res.json())
            .then(data => setContactsData(data))
            .catch(err => console.error("Error fetching contacts:", err));
    };

    return (
        <div>
            <button onClick={handleFetch}>Fetch Contacts</button>
            <div style={{ display: 'flex', flexWrap: 'wrap', gap: '1rem', marginTop: '1rem' }}>
                {contactsData.map((c) => (
                    <div key={c.id} style={{ border: '1px solid #ccc', padding: '10px', width: '200px' }}>
                        <img src={c.photo} alt={c.name} style={{ width: '100%', height: 'auto' }} />
                        <h3>{c.name}</h3>
                        <p>📞 {c.phoneNo}</p>
                    </div>
                ))}
            </div>
        </div>
    );
}

// Main component
export default function Ex04FetchApiDemo() {
    const [contactsData, setContactsData] = useState([]);

    return (
        <ContactContext.Provider value={[contactsData, setContactsData]}>
            <div style={{ padding: '20px' }}>
                <h2>Contact List</h2>
                <hr />
                <ContactDB />
            </div>
        </ContactContext.Provider>
    );
}
