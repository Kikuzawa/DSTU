import re


def lab13_1(text):
    pattern = r'^abcdefghijklmnopqrstuv18340'
    return str(bool(re.match(pattern, text)))


def lab13_2(text):
    pattern = r"^[A-Za-z0-9]{8}-[A-Za-z0-9]{4}-[A-Za-z0-9]{4}-[A-Za-z0-9]{4}-[A-Za-z0-9]{12}"
    return str(bool(re.match(pattern, text)))


def lab13_3(text):
    pattern = r'^([0-9A-Fa-f]{2}[:-]){5}([0-9A-Fa-f]{2})$'
    return str(bool(re.match(pattern, text)))


def lab13_4(text):
    regex = ("((http|https)://)(www.)?" +
             "[a-zA-Z0-9@:%.\\+~#?&//=]" +
             "{2,256}\\.[a-z]" +
             "{2,6}\\b([-a-zA-Z0-9@:%" +
             ".\\+~#?&//=]*)")
    pattern_ip = r'\b(?:\d{1,3}\.){3}\d{1,3}\b'
    if bool(re.search(pattern_ip, text)):
        return False
    else:
        return str(bool(re.match(regex, text)))


def lab13_5(text):
    pattern = r'^#[A-Fa-f0-9]{6}$'
    return str(bool(re.match(pattern, text)))


def lab13_6(text):
    pattern = r'^(0[1-9]|1\d|2[0-8])/(0[1-9]|1[0-2])/((?:1[6-9]|[2-9]\d)?\d{2})$|^29/02/(?:(?:(?:1[6-9]|[2-9]\d)(?:0[' \
              r'48]|[2468][048]|[13579][26]))|(?:16|[2468][048]|[3579][26])00)$'
    return str(bool(re.match(pattern, text)))


def lab13_7(text):
    pattern = r'^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+.[a-zA-Z]{2,}$'
    return str(bool(re.match(pattern, text)))


def lab13_8(text):
    pattern = r"^([0-9]{1,3}[\.]){3}[0-9]{1,3}$"
    return bool(re.fullmatch(pattern, text.strip()))


def lab13_9(text):
    pattern = r'^[a-zA-Z0-9_]{8,}'
    if bool(re.match(pattern, text)) and re.search(r'[A-Z]', text) and re.search(r'[a-z]', text) and re.search(r'\d',
                                                                                                               text):
        return 'True'
    else:
        return 'False'


def lab13_10(text):
    pattern = r'^[1-9]{6}$'
    return str(bool(re.match(pattern, text)))


def lab13_11(text):
    pattern = r'(?:^|[\n\r]|[^\w\d\.])([1-9]\d*(?:.\d{,2})?\s*(?:USD|EU|RUR))\b'
    return "\n".join(re.findall(pattern, text))


def lab13_12(text):
    pattern = r'\b\d+(?:\s*\+)'
    return str(bool(re.search(pattern, text.strip())))


def lab13_13(text):
    match = re.fullmatch(r'[^()]*((\([^()]*\)[^()]*)*)', text.strip())
    return str(match and match.group(0).count('(') == match.group(0).count(')'))
