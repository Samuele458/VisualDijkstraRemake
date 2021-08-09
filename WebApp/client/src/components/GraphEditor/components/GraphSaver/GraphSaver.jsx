import React, { useEffect, useState } from "react";
import * as GraphUtils from "../../../../utils/graphUtils";
import axios from "axios";
import Lodash from "lodash";

const GraphSaver = (props) => {
  useEffect(() => {}, [props.a.current]);

  return <p>Saver {props.a.current}</p>;
};

export default GraphSaver;
