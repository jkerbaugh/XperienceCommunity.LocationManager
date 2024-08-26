import Radar from 'radar-sdk-js';
import React, {useEffect, useRef} from "react";

import {FormComponentProps} from "@kentico/xperience-admin-base";
import {FormItemWrapper, Input} from "@kentico/xperience-admin-components";

import 'radar-sdk-js/dist/radar.css';
import './radar.scss'
import {Geolocation} from "../Models/Geolocation";

interface RadarAddressProperties extends FormComponentProps {
    readonly apiKey: string
}

export const RadarAddressSelectorFormComponent = (
    {
        apiKey,
        name,
        label,
        required,
        onChange,
        value,
        explanationText,
        disabled,
        invalid,
        validationMessage,
        tooltip
    }: RadarAddressProperties) => {
    const autocompleteRef: React.MutableRefObject<any> = useRef(null);
    const radarInitialized: React.MutableRefObject<any> = useRef(false);
    const mapRef: React.MutableRefObject<any> = useRef(null);
    const markerRef: React.MutableRefObject<any> = useRef(null);
    
    useEffect(() => {
        const {latitude, longitude, formattedAddress} = value;
        const center: any = [longitude, latitude];
        Radar.initialize(apiKey);

        const map = Radar.ui.map({
            container: `${name}_map`,
            style: 'radar-default-v1',
            center: center, // NYC
            zoom: 14,
        });
        mapRef.current = map;

        // Add a marker to the map
        const marker = Radar.ui.marker({ popup: {text: formattedAddress }})
            .setLngLat(center)
            .addTo(map);
        markerRef.current = marker;
        
        autocompleteRef.current = Radar.ui.autocomplete({
            container: `${name}_ac`,
            width: '100%',
            placeholder: value.formattedAddress,
            disabled: disabled,
            onSelection: ({latitude, longitude, formattedAddress, addressLabel, city, country, county}) => {
                markerRef.current.setLngLat([longitude, latitude]);
                marker.getPopup().setText(formattedAddress);
                mapRef.current.flyTo({ center: [longitude, latitude], zoom: 14 });
                
                if (onChange) {
                    const location: Geolocation = {
                        latitude: latitude,
                        longitude: longitude,
                        formattedAddress: formattedAddress,
                        addressLabel: addressLabel,
                        city: city,
                        country: country,
                        county: county,
                    }

                    onChange(location);
                }
            },
        });
        
        
        return () => {
            autocompleteRef.current?.remove();
        };


    }, []);
    
    return (
        <FormItemWrapper
            label={label}
            disabled={disabled}
            explanationText={explanationText}
            invalid={invalid}
            validationMessage={validationMessage}
            markAsRequired={required}
            labelIcon={tooltip ? 'xp-i-circle' : undefined}
            labelIconTooltip={tooltip}>
            <div id={`${name}_ac`}></div>
            <div id={`${name}_map`} />
        </FormItemWrapper>
    )
}
