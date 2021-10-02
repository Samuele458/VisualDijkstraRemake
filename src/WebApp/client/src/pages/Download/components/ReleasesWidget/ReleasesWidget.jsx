import React, { useState, useEffect } from "react";

import ReleaseBox from "../ReleaseBox/ReleaseBox";

const ReleasesWidget = () => {
  const [releases, setReleases] = useState([]);

  useEffect(() => {
    (async () => {
      const response = await fetch(
        "https://api.github.com/repos/samuele458/visualdijkstraremake/releases"
      );
      setReleases(await response.json());

      console.log(releases);
    })();
    // eslint-disable-next-line
  }, []);

  return (
    <div className="releases">
      {releases.map((release, i) => {
        return (
          <ReleaseBox
            version={release.tag_name}
            latest={i === 0}
            winLink={release.assets[0].browser_download_url}
            date={release.created_at}
            notes={release.body}
            sourceLink={release.zipball_url}
            githubLink={release.html_url}
          />
        );
      })}
    </div>
  );
};

export default ReleasesWidget;
