import React from "react";

import Releases from "./components/ReleasesWidget";

import Logo from "../../logo.png";
import Footer from "../../components/Footer";
import MetaTags from "react-meta-tags";

const DownloadPage = () => {
  return (
    <>
      <MetaTags>
        <title>Download | Visual Dijkstra</title>
        <meta property="og:title" content="Download | Visual Dijkstra" />
      </MetaTags>
      <section className="download-header-section">
        <h1 className="title-light download-title">Download latest version.</h1>
        <div className="custom-shape-divider-bottom-1620733493">
          <svg
            dataName="Layer 1"
            xmlns="http://www.w3.org/2000/svg"
            viewBox="0 0 1200 120"
            preserveAspectRatio="none"
          >
            <path
              d="M1200 120L0 16.48 0 0 1200 0 1200 120z"
              class="shape-fill"
            ></path>
          </svg>
        </div>
      </section>
      <section className="download-main-section hflex-responsive">
        <Releases />
        <img src={Logo} alt="" className="logo zoom-1" />
      </section>
      <Footer />
    </>
  );
};

export default DownloadPage;
