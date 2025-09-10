

export default function Footer() {
    const year: number = new Date().getFullYear();
  return (
    <div>
        <hr/>
        <i>&copy;All Rights are Reserved - Powered by React-19.x - {year}</i>
    </div>
  )
}
