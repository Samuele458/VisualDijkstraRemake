import React from "react";
import Screen001 from "./screen001.png";
import Logo from "../../logo.png";
import Feature from "./components/Feature/Feature";
import featureslist from "./featureslist";
import Footer from "../../components/Footer/Footer";

import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { faGithub } from "@fortawesome/free-brands-svg-icons";
import { faDownload, faRoute } from "@fortawesome/free-solid-svg-icons";

import { HashLink as Link } from "react-router-hash-link";

import MetaTags from "react-meta-tags";

const Home = () => {
  return (
    <>
      <MetaTags>
        <title>Visual Dijkstra</title>
        <meta property="og:title" content="Visual Dijkstra" />
      </MetaTags>
      <section className="header-section" id="home">
        <div className="hflex-responsive">
          <div className="vflex-center intro-box">
            <img src={Logo} alt="" className="logo zoom-1" />
            <h1 className="title-light">Visual Dijkstra</h1>
            <h2 className="text-light">Free and Open Source graph editor.</h2>
            <div className="btn-group">
              <Link to="/app" className="btn-white zoom-2">
                <FontAwesomeIcon icon={faRoute} className="btn-image" />
                WebApp
              </Link>
              <Link to="/download" className="btn-light zoom-2">
                <FontAwesomeIcon icon={faDownload} className="btn-image" />
                Download
              </Link>
              <a
                href="https://github.com/samuele458/visual-dijkstra"
                className="btn-black zoom-2"
              >
                <FontAwesomeIcon icon={faGithub} className="btn-image" />
                Github
              </a>
            </div>
          </div>
          <img src={Screen001} alt="" className="screen zoom-1" />
        </div>

        <div className="custom-shape-divider-bottom-1620659300">
          <svg
            dataName="Layer 1"
            xmlns="http://www.w3.org/2000/svg"
            viewBox="0 0 1200 120"
            preserveAspectRatio="none"
          >
            <path
              d="M0,0V46.29c47.79,22.2,103.59,32.17,158,28,70.36-5.37,136.33-33.31,206.8-37.5C438.64,32.43,512.34,53.67,583,72.05c69.27,18,138.3,24.88,209.4,13.08,36.15-6,69.85-17.84,104.45-29.34C989.49,25,1113-14.29,1200,52.47V0Z"
              opacity=".25"
              className="shape-fill"
            ></path>
            <path
              d="M0,0V15.81C13,36.92,27.64,56.86,47.69,72.05,99.41,111.27,165,111,224.58,91.58c31.15-10.15,60.09-26.07,89.67-39.8,40.92-19,84.73-46,130.83-49.67,36.26-2.85,70.9,9.42,98.6,31.56,31.77,25.39,62.32,62,103.63,73,40.44,10.79,81.35-6.69,119.13-24.28s75.16-39,116.92-43.05c59.73-5.85,113.28,22.88,168.9,38.84,30.2,8.66,59,6.17,87.09-7.5,22.43-10.89,48-26.93,60.65-49.24V0Z"
              opacity=".5"
              className="shape-fill"
            ></path>
            <path
              d="M0,0V5.63C149.93,59,314.09,71.32,475.83,42.57c43-7.64,84.23-20.12,127.61-26.46,59-8.63,112.48,12.24,165.56,35.4C827.93,77.22,886,95.24,951.2,90c86.53-7,172.46-45.71,248.8-84.81V0Z"
              className="shape-fill"
            ></path>
          </svg>
        </div>
      </section>
      <section className="presentation-section">
        <div className="vflex content">
          <div className="hflex-responsive">
            <div className="vflex">
              <h2 className="title intro-text">
                Visual Dijkstra helps you understand how Dijsktra's algorithm
                works.
              </h2>
            </div>
            <img src={Logo} alt="" className="logo zoom-3" />
          </div>
          <div className="hflex-responsive features">
            {featureslist.map((feature, i) => {
              return (
                <Feature
                  title={feature.title}
                  text={feature.text}
                  icon={feature.icon}
                />
              );
            })}
          </div>
        </div>
      </section>
      <Footer />
    </>
  );
};

export default Home;
