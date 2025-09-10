import { Routes, Route, Navigate } from 'react-router-dom';
import Navbar from './Components/Navbar';
import AddContact from './Components/AddContact';
import EditContact from './Components/EditContact';
import ContactList from './Components/ContactList';
import ViewContact from './Components/ViewContact';

function App() {
  return (
    <>
      <Navbar />
      <Routes>
        <Route path="/" element={<Navigate to="/contacts/all" />} />
        <Route path="/contacts/all" element={<ContactList />} />
        <Route path="/contacts/add" element={<AddContact />} />
        <Route path="/contacts/update/:id" element={<EditContact />} />
        <Route path="/contacts/view/:id" element={<ViewContact />} />
      </Routes>
    </>
  );
}

export default App;
