import React, { useEffect, useState } from "react";
import marked from "marked";

import MetaTags from "react-meta-tags";

const parseMarkdown = (source) => {
  if (typeof source === "string") return { __html: marked(source) };
  else
    return (
      <div className="loading-box">
        <p className="loading-text">Loading...</p>
      </div>
    );
};

const Policy = (props) => {
  const [mdSource, setMdSource] = useState([]);

  const loadFile = (path) => {
    fetch(path)
      .then((response) => {
        return response.text();
      })
      .then((text) => {
        setMdSource(text);
      });
  };

  useEffect(() => {
    loadFile(props.filePath);
  });

  const content = parseMarkdown(mdSource);

  let contentBox;
  if (typeof content.__html === "string") {
    contentBox = (
      <div
        className="markdown-area policy-text"
        dangerouslySetInnerHTML={content}
      ></div>
    );
  } else {
    contentBox = <div className="markdown-area policy-text">{content}</div>;
  }

  return (
    <section className="policy-section">
      <MetaTags>
        <title>Policy | Visual Dijkstra</title>
        <meta property="og:title" content="Policy | Visual Dijkstra" />
      </MetaTags>
      {contentBox}
    </section>
  );
};

export default Policy;
