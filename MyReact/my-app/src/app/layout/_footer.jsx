export default function Footer() {
  return (
    <>
      <footer className="col-12 bg-dark text-light py-3 mt-5">
        <div className="container">
          <div className="row">
            <div className="col-md-6">
              <h4>Company Name</h4>
              <p>
                Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer
                nec odio.
              </p>
            </div>
            <div className="col-md-3">
              <h4>Quick Links</h4>
              <ul className="list-unstyled">
                <li>
                  <a href="#">Home</a>
                </li>
                <li>
                  <a href="#">About</a>
                </li>
                <li>
                  <a href="#">Services</a>
                </li>
                <li>
                  <a href="#">Contact</a>
                </li>
              </ul>
            </div>
            <div className="col-md-3">
              <h4>Contact Us</h4>
              <p>Address: 123 Main St, City, Country</p>
              <p>Email: info@example.com</p>
              <p>Phone: +1 123-456-7890</p>
            </div>
          </div>
          <hr />
          <div className="row">
            <div className="col-md-12 text-center">
              <p>&copy; 2023 Company Name. All rights reserved.</p>
            </div>
          </div>
        </div>
      </footer>
    </>
  );
}
