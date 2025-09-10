import axios from "axios";
export class ContactService{
    static baseUrl = "http://localhost:5182/contacts";

    static getAllContacts = () => axios.get(this.baseUrl);
    static getContactById =(id)=> axios.get(`${this.baseUrl}/${id}`);
    static addContact =(c) => axios.post(this.baseUrl,c);
    static deleteContact = (id) => {
        const url =`${this.baseUrl}/${id}`;
        axios.delete(url);
    }

    static updateContact = (c)=>{
        const url = `${this.baseUrl}/${c.id}`;
        return axios.put(url,c);
    }
}