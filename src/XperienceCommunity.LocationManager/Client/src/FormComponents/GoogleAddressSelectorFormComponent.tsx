import React, {useEffect, useRef} from "react";
interface GoogleAddressProperties {
    readonly apiKey: string
}

export const GoogleAddressSelectorFormComponent = ({apiKey}: GoogleAddressProperties) => {
    const radarInitialized = useRef(false);
    const autocompleteRef: React.MutableRefObject<any> = useRef(null);

    console.log(apiKey)

    useEffect(() => {

        // autocompleteRef.current = Radar.ui.autocomplete({
        //     container: 'autocomplete',
        //     width: '400px',
        //     onSelection: (address) => {
        //         const { latitude, longitude } = address;
        //         console.log('Selected address:', address);
        //     },
        // });
        // return () => {
        //     autocompleteRef.current?.remove();
        // };
    }, []);


    return (
        <div>
            <p>Google Hello</p>
            <div id="autocomplete" style={{width: '400px', padding: '10px'}}/>
        </div>
    )
}
