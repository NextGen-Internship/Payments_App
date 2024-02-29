

const PageNavButtons = ({ index, onShow, page }: any) => {
    return (
      <div
        style={{
          cursor: 'pointer',
          backgroundColor: 'transparent',
          padding: '8px', 
          margin: '4px',
        }}
        onClick={() => onShow(index)}
      >
        {page.pageName}
      </div>
    );
  };
  
  export default PageNavButtons;