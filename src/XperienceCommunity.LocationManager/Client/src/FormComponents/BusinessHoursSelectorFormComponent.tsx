import React from "react";
import {FormComponentProps} from "@kentico/xperience-admin-base";
import {
    DateTimePicker,
    DateTimePickerTimeFormat,
    FormItemWrapper,
    TimePicker
} from "@kentico/xperience-admin-components";
import TimeRangePicker from "@wojtekmaj/react-timerange-picker";


interface BusinessHoursSelectorProps extends FormComponentProps {
    
}

export const BusinessHoursSelectorFormComponent = (
    {
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
    }: BusinessHoursSelectorProps) => {

  

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
            <div>
                <label>Monday</label>
                <TimeRangePicker/>
            </div>
            
        </FormItemWrapper>
    )
}
