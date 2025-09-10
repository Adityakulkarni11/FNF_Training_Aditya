import myPic from './assets/pic1.png'

export default function Profile() {
    //data shall come here...
    const title = "Aditya"
    const info = "I am a React Developer. I love to work on React and its ecosystem. I have worked on many projects using React and its libraries like Redux, Router, etc."
    return (
        <div className="container">
            <div className="row">
                <div className="col-md-2"></div>
                <div className="col-md-8">
                    <div className="card">
                        <img 
                            className="card-image img-thumbnail rounded-circle card-sm mx-auto d-block" 
                            src={myPic}
                            style={{ width: '120px', height: '120px', objectFit: 'cover' }} 
                        />
                        <h2 className="card-title">{title}</h2>
                        <hr />
                        <p className="card-text">{info}</p>
                    </div>
                </div>
            </div>
        </div>
    )
}
