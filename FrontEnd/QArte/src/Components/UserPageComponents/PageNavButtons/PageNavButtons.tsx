import * as React from 'react';
import Button from '@mui/material/Button';

const PageNavButtons = ({ id, onShow, index }: any) => {
    return (
      <div
        style={{
          cursor: 'pointer',
          backgroundColor: 'transparent',
          padding: '8px', 
          margin: '4px',
        }}
        onClick={() => onShow(id)}
      >
        Page {index + 1}
      </div>
    );
  };
  
  export default PageNavButtons;