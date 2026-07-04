#!/bin/bash

set -e

echo "Uploading IPA to App Store Connect..."

PATH_TO_IPA="$WORKSPACE/.build/last/$TARGET_NAME/build.ipa"

if [ ! -f "$PATH_TO_IPA" ]; then
    echo "Error: IPA not found:"
    echo "$PATH_TO_IPA"
    exit 1
fi

if xcrun altool \
    --upload-app \
    --type ios \
    --file "$PATH_TO_IPA" \
    --username "$ITUNES_USERNAME" \
    --password "$ITUNES_PASSWORD"
then
    echo "Upload to App Store Connect succeeded."
else
    echo "Upload to App Store Connect failed."
    exit 1
fi