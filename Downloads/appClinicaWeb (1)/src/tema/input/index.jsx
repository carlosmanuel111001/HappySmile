export const Input = ({
    label,
    id,
    options,
    className,
    value,
    onChange,
    placeholder,
    disable,
    inputProps = {}
}) => {
    return (
        <div className={`form-input ${className}`}>
            <label htmlFor={id}>
                {label}
            </label>
            {!options ? (
                <input
                    id={id}
                    value={value}
                    placeholder={placeholder}
                    onChange={onChange}
                    {...inputProps}
                />
            ) : (
                <select
                    value={value}
                    onChange={onChange}
                    {...inputProps}
                >
                    <option>
                        {!placeholder ? (
                            'Seleccionar'
                        ) : (
                            placeholder
                        )}
                    </option>
                    {options && options.length > 0 && options.map(item => (
                        <option
                            key={item.value}
                            value={item.value}
                        >
                            {item.text}
                        </option>
                    ))}
                </select>
            )}
        </div>
    );
};